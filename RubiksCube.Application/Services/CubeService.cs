using System.Collections.Immutable;
using System.Text;
using RubiksCube.Domain.Common;
using RubiksCube.Domain.DTOs;
using RubiksCube.Domain.Enums;
using RubiksCube.Domain.Models;

namespace RubiksCube.Application.Services;

public class CubeService(Cube cube) : ICubeService
{
    private readonly Cube _cube = cube;

    private static readonly ImmutableDictionary<Face, (Face face, Func<int, (int x, int y)> getPos)[]> AdjacentEdges =
        new Dictionary<Face, (Face, Func<int, (int, int)>)[]>
        {
            [Face.Front] =
            [
                (Face.Up, i => (2, i)),
                (Face.Right, i => (i, 0)),
                (Face.Down, i => (0, 2 - i)),
                (Face.Left, i => (2 - i, 2))
            ],
            [Face.Back] =
            [
                (Face.Up, i => (0, 2 - i)),
                (Face.Left, i => (i, 0)),
                (Face.Down, i => (2, i)),
                (Face.Right, i => (2 - i, 2))
            ],
            [Face.Up] =
            [
                (Face.Back, i => (0, 2 - i)),
                (Face.Right, i => (0, 2 - i)),
                (Face.Front, i => (0, i)),
                (Face.Left, i => (0, i))
            ],
            [Face.Down] =
            [
                (Face.Front, i => (2, i)),
                (Face.Right, i => (2, i)),
                (Face.Back, i => (2, 2 - i)),
                (Face.Left, i => (2, 2 - i))
            ],
            [Face.Left] =
            [
                (Face.Up, i => (i, 0)),
                (Face.Front, i => (i, 0)),
                (Face.Down, i => (i, 0)),
                (Face.Back, i => (2 - i, 2))
            ],
            [Face.Right] =
            [
                (Face.Up, i => (i, 2)),
                (Face.Back, i => (2 - i, 0)),
                (Face.Down, i => (i, 2)),
                (Face.Front, i => (i, 2))
            ]
        }.ToImmutableDictionary();

    public Result Rotate(RotateRequest request)
    {
        RotateFaceMatrix(request.Face, request.Clockwise);
        RotateEdges(request.Face, request.Clockwise);
        
        return Result.Success();
    }

    public Result<CubeStateDto> GetState()
    {
        var cubeState = new CubeStateDto([
            PrintFace(_cube.GetFaceState(Face.Front)),
            PrintFace(_cube.GetFaceState(Face.Back)),
            PrintFace(_cube.GetFaceState(Face.Up)),
            PrintFace(_cube.GetFaceState(Face.Down)),
            PrintFace(_cube.GetFaceState(Face.Left)),
            PrintFace(_cube.GetFaceState(Face.Right))]);

        return Result<CubeStateDto>.Success(cubeState);
    }

    public Result Reset()
    {
        _cube.ResetCube();
        return Result.Success();
    }

    private void RotateFaceMatrix(Face face, bool clockwise)
    {
        var size = _cube.Size;
        var faceMatrix = _cube[face];
        var rotated = new Color[size, size];

        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            rotated[i, j] = clockwise ? faceMatrix[size - j - 1, i] : faceMatrix[j, size - i - 1];

        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            _cube[face, i, j] = rotated[i, j];
    }

    private void RotateEdges(Face face, bool clockwise)
    {
        var mappings = AdjacentEdges[face];
        var size = _cube.Size;
        var temp = new Color[size];

        for (int i = 0; i < size; i++)
        {
            var (x, y) = mappings[0].getPos(i);
            temp[i] = _cube[mappings[0].face, x, y];
        }

        if (clockwise)
        {
            for (int i = 0; i < mappings.Length - 1; i++)
            for (int j = 0; j < size; j++)
            {
                var (srcX, srcY) = mappings[i + 1].getPos(j);
                var (dstX, dstY) = mappings[i].getPos(j);
                _cube[mappings[i].face, dstX, dstY] = _cube[mappings[i + 1].face, srcX, srcY];
            }

            for (int j = 0; j < size; j++)
            {
                var (dstX, dstY) = mappings[^1].getPos(j);
                _cube[mappings[^1].face, dstX, dstY] = temp[j];
            }
        }
        else
        {
            for (int i = mappings.Length - 1; i > 0; i--)
            for (int j = 0; j < size; j++)
            {
                var (srcX, srcY) = mappings[i - 1].getPos(j);
                var (dstX, dstY) = mappings[i].getPos(j);
                _cube[mappings[i].face, dstX, dstY] = _cube[mappings[i - 1].face, srcX, srcY];
            }

            for (int j = 0; j < size; j++)
            {
                var (dstX, dstY) = mappings[0].getPos(j);
                _cube[mappings[0].face, dstX, dstY] = temp[j];
            }
        }
    }
    
    private static string PrintFace(Color[,] face)
    {
        var rows = face.GetLength(0);
        var cols = face.GetLength(1);
        var output = new StringBuilder();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                output.Append(face[i, j].ToString()[0]); // First char of each color
                output.Append(' ');
            }
            output.AppendLine();
        }

        return output.ToString();
    }
}
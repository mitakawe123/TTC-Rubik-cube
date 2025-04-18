using System.Collections.Immutable;
using RubiksCube.Domain.Enums;
using RubiksCube.Domain.Models;

namespace RubiksCube.Application.Services;

public class CubeService(Cube cube) : ICubeService
{
    private readonly Cube _cube = cube;
    
    // We don't include the center part of each face because it doesn't influence the edges when rotating 
    private static readonly ImmutableDictionary<Face, (int, int)[]> EdgeMappings = new Dictionary<Face, (int, int)[]>
    {
        { Face.Front, [(0, 0), (0, 1), (0, 2), (1, 0), (2, 0), (2, 1), (2, 2), (1, 2)] },
        { Face.Up, [(0, 0), (0, 1), (0, 2), (1, 0), (2, 0), (2, 1), (2, 2), (1, 2)] },
        { Face.Down, [(2, 0), (2, 1), (2, 2), (1, 2), (0, 2), (0, 1), (0, 0), (1, 0)] },
        { Face.Left, [(0, 0), (1, 0), (2, 0), (2, 1), (2, 2), (0, 1), (0, 2)] },
        { Face.Right, [(0, 2), (1, 2), (2, 2), (2, 1), (2, 0), (0, 1), (0, 0)] },
        { Face.Back, [(0, 2), (0, 1), (0, 0), (1, 0), (2, 0), (2, 1), (2, 2), (1, 2)] }
    }.ToImmutableDictionary();

    public void Rotate(Face face, bool clockwise)
    {
        RotateFaceMatrix(face, clockwise);
        RotateEdges(face, clockwise);
    }

    private void RotateFaceMatrix(Face face, bool clockwise)
    {
        var faceMatrix = GetFaceMatrix(face);

        var rotated = new Color[3, 3];
        for (var i = 0; i < 3; i++)
        for (var j = 0; j < 3; j++)
        {
            rotated[i, j] = clockwise ? faceMatrix[2 - j, i] : faceMatrix[j, 2 - i];
        }

        SetFaceMatrix(face, rotated);
    }

    private Color[,] GetFaceMatrix(Face face)
    {
        return face switch
        {
            Face.Up => _cube.Up,
            Face.Down => _cube.Down,
            Face.Left => _cube.Left,
            Face.Right => _cube.Right,
            Face.Front => _cube.Front,
            Face.Back => _cube.Back,
            _ => throw new ArgumentException("Invalid face")
        };
    }

    private void SetFaceMatrix(Face face, Color[,] newMatrix)
    {
        switch (face)
        {
            case Face.Up:
                _cube.Up = newMatrix;
                break;
            case Face.Down:
                _cube.Down = newMatrix;
                break;
            case Face.Left:
                _cube.Left = newMatrix;
                break;
            case Face.Right:
                _cube.Right = newMatrix;
                break;
            case Face.Front:
                _cube.Front = newMatrix;
                break;
            case Face.Back:
                _cube.Back = newMatrix;
                break;
            default:
                throw new ArgumentException("Invalid face");
        }
    }

    private void RotateEdges(Face face, bool clockwise)
    {
        // Get the edge positions for the face
        var edgePositions = EdgeMappings[face];
        var temp = new Color[edgePositions.Length];

        // Collect the edge colors into a temporary array
        foreach (var (x, y) in edgePositions)
        {
            
        }

        // Determine the adjacent faces and edges affected by the rotation
        if (clockwise)
        {
            RotateClockwise(face);
        }
        else
        {
            RotateCounterClockwise(face);
        }
    }
    
    private static void RotateClockwise(Face face) {}
    
    private static void RotateCounterClockwise(Face face) {}
}
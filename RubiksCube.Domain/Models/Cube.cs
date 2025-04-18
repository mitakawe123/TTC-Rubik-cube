using RubiksCube.Domain.Enums;

namespace RubiksCube.Domain.Models;

public class Cube
{
    private readonly Color[][,] _faces;

    public int Size { get; }

    public Cube(int size = 3)
    {
        Size = size;
        _faces = new Color[6][,];

        for (int i = 0; i < 6; i++)
        {
            _faces[i] = CreateFace((Color)i, size);
        }
    }

    private static Color[,] CreateFace(Color color, int size)
    {
        var face = new Color[size, size];
        for (int row = 0; row < size; row++)
        for (int col = 0; col < size; col++)
            face[row, col] = color;
        return face;
    }

    /// <summary>
    /// Access an entire face: cube[Face.Front]
    /// </summary>
    public Color[,] this[Face face] => _faces[(int)face];

    /// <summary>
    /// Access a single tile: cube[Face.Front, row, col]
    /// </summary>
    public Color this[Face face, int row, int col]
    {
        get => _faces[(int)face][row, col];
        set => _faces[(int)face][row, col] = value;
    }
}
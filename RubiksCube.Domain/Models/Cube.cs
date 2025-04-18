using RubiksCube.Domain.Enums;

namespace RubiksCube.Domain.Models;

public class Cube
{
    public int Size { get; private set; }
    private Color[][,] Faces { get; set; } =  []; 

    public Cube(int size = 3)
    {
        ResetCube(size);
    }

    /// <summary>
    /// Access an entire face: cube[Face.Front]
    /// </summary>
    public Color[,] this[Face face] => Faces[(int)face];

    /// <summary>
    /// Access a single tile: cube[Face.Front, row, col]
    /// </summary>
    public Color this[Face face, int row, int col]
    {
        get => Faces[(int)face][row, col];
        set => Faces[(int)face][row, col] = value;
    }

    public void ResetCube(int size = 3)
    {
        Size = size;
        Faces = new Color[6][,];

        for (var i = 0; i < 6; i++)
        {
            Faces[i] = CreateFace((Color)i, size);
        }
    }
    
    public Color[,] GetFaceState(Face face)
    {
        return Faces[(int)face];
    }
    
    private static Color[,] CreateFace(Color color, int size)
    {
        var face = new Color[size, size];
        for (int row = 0; row < size; row++)
        for (int col = 0; col < size; col++)
            face[row, col] = color;
        return face;
    }
}
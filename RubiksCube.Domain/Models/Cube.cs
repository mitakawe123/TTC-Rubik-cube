using RubiksCube.Domain.Enums;

namespace RubiksCube.Domain.Models;

public abstract class Cube
{
    public Color[,] Up { get; set; } = CreateFace(Color.White);
    public Color[,] Down { get; set; } = CreateFace(Color.Yellow);
    public Color[,] Left { get; set; } = CreateFace(Color.Orange);
    public Color[,] Right { get; set; } = CreateFace(Color.Red);
    public Color[,] Front { get; set; } = CreateFace(Color.Green);
    public Color[,] Back { get; set; } = CreateFace(Color.Blue);

    // Initial setup of the cube (solved)
    private static Color[,] CreateFace(Color color)
    {
        return new[,]
        {
            { color, color, color },
            { color, color, color },
            { color, color, color }
        };
    }
}
using RubiksCube.Application.Services;
using RubiksCube.Domain.DTOs;
using RubiksCube.Domain.Enums;
using RubiksCube.Domain.Models;

namespace RubiksCube.Tests;

public class CubeServiceTests
{
    private readonly Cube _cube;
    private readonly CubeService _service;

    public CubeServiceTests()
    {
        _cube = new Cube(); 
        _service = new CubeService((_cube));
    }

    [Fact]
    public void Rotate_ShouldRotateFace_AndReturnSuccess()
    {
        // Arrange
        var request = new RotateRequest(Face.Front,true);

        // Act
        var result = _service.Rotate(request);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void GetState_ShouldReturnAllSixFaces()
    {
        // Act
        var result = _service.GetState();

        // Assert
        Assert.True(result.IsSuccess);
        var state = result.Value;
        Assert.NotNull(state);
        Assert.Equal(6, state.Faces.Length);
        foreach (var face in state.Faces)
        {
            Assert.False(string.IsNullOrWhiteSpace(face));
        }
    }

    [Fact]
    public void Reset_ShouldResetCubeToInitialState()
    {
        // Arrange
        _service.Rotate(new RotateRequest(Face.Left, true)); // Rotate the cube to change its state
    
        // Act
        var result = _service.Reset();

        // Assert
        Assert.True(result.IsSuccess);

        var resetCube = new Cube(); 
        var expectedFront = resetCube.GetFaceState(Face.Front);
        var actualFront = _cube.GetFaceState(Face.Front);

        // Compare the expected (reset) front face to the actual front face
        for (int i = 0; i < _cube.Size; i++)
        {
            for (int j = 0; j < _cube.Size; j++)
            {
                Assert.Equal(expectedFront[i, j], actualFront[i, j]);
            }
        }
    }

    [Fact]
    public void Scramble_ShouldApplyMoves_AndReturnSuccess()
    {
        // Act
        var result = _service.Scramble();

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData(Face.Right)]
    [InlineData(Face.Up)]
    [InlineData(Face.Down)]
    public void Rotate_ShouldWorkForAllFaces(Face face)
    {
        var result = _service.Rotate(new RotateRequest(face,false));
        Assert.True(result.IsSuccess);
    }
}

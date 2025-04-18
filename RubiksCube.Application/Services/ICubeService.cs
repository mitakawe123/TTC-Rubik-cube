using RubiksCube.Domain.Enums;

namespace RubiksCube.Application.Services;

public interface ICubeService
{
    void Rotate(Face face, bool clockwise);
}
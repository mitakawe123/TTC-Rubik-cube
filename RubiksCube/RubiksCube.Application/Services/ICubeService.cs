using RubiksCube.Domain.Common;
using RubiksCube.Domain.DTOs;

namespace RubiksCube.Application.Services;

public interface ICubeService
{
    Result Rotate(RotateRequest request);

    Result<CubeStateDto> GetState();

    Result Reset();
}

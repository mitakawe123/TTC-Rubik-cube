using RubiksCube.Domain.Enums;

namespace RubiksCube.Domain.DTOs;

public record RotateRequest(Face Face, bool Clockwise);
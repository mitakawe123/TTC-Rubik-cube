using Microsoft.AspNetCore.Mvc;
using RubiksCube.Application.Services;
using RubiksCube.Domain.DTOs;

namespace RubiksCube.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CubeController(ICubeService cubeService) : ControllerBase
{
    private readonly ICubeService _cubeService = cubeService;
    
    [HttpGet("state")]
    public IActionResult GetState()
    {
        var result = _cubeService.GetState();
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpPatch("rotate")]
    public IActionResult RotateFace([FromBody] RotateRequest request)
    { 
        var result = _cubeService.Rotate(request);
        return result.IsSuccess
            ? NoContent()
            : BadRequest(result.Error);
    }

    [HttpPatch("reset")]
    public IActionResult Reset()
    {
        var result = _cubeService.Reset();
        return result.IsSuccess
            ? NoContent()
            : BadRequest(result.Error);
    }

}
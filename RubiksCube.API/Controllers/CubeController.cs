using Microsoft.AspNetCore.Mvc;
using RubiksCube.Application.Services;
using RubiksCube.Domain.DTOs;

namespace RubiksCube.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CubeController(ICubeService cubeService)
{
    [HttpGet("state")]
    public async Task GetState()
    { 
        
    }
    
    [HttpPatch("rotate")]
    public async Task RotateFace([FromBody] RotateRequest request)
    { 
        
    }

    [HttpPatch("reset")]
    public async Task Reset()
    {
        
    }
}
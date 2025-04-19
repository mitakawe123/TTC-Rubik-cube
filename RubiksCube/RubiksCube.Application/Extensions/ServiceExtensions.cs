using Microsoft.Extensions.DependencyInjection;
using RubiksCube.Application.Services;
using RubiksCube.Domain.Models;

namespace RubiksCube.Application.Extensions;

public static class ServiceExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services
            .AddSingleton<Cube>()
            .AddSingleton<ICubeService, CubeService>();
    }
}

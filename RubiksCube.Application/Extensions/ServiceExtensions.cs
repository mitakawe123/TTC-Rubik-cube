using Microsoft.Extensions.DependencyInjection;
using RubiksCube.Application.Services;

namespace RubiksCube.Application.Extensions;

public static class ServiceExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<ICubeService, CubeService>();
    }
}

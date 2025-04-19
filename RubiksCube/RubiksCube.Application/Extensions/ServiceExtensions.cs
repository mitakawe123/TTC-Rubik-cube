using Microsoft.Extensions.DependencyInjection;
using RubiksCube.Application.Middlewares;
using RubiksCube.Application.Services;
using RubiksCube.Domain.Models;

namespace RubiksCube.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<Cube>()
            .AddSingleton<ICubeService, CubeService>();
    }

    public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
    {
        return services.AddExceptionHandler<GlobalExceptionHandler>();
    } 

    public static IServiceCollection AddCorsServices(this IServiceCollection services)
    {
        return services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:5173") 
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}

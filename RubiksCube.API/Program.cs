using RubiksCube.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices(); 

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
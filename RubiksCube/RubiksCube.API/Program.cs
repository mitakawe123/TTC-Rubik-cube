using RubiksCube.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCoreServices()
    .AddCorsServices()
    .AddExceptionHandler();

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseCors("AllowFrontend");
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
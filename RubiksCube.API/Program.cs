using RubiksCube.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices(); 
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
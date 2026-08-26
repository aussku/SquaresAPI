using SquaresAPI.src.Repos;
using SquaresAPI.src.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IPointsRepo, PointsRepo>();
builder.Services.AddScoped<IPointsService, PointsService>();

var app = builder.Build();

app.MapControllers();

app.Run();

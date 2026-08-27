using SquaresAPI.src.Repositories;
using SquaresAPI.src.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IPointsRepository, PointsRepository>();
builder.Services.AddScoped<IPointsService, PointsService>();

var app = builder.Build();

app.MapControllers();

app.Run();

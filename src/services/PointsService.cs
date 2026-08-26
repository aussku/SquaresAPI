using SquaresAPI.src.DTOs;
using SquaresAPI.src.Models;
using SquaresAPI.src.Repos;

namespace SquaresAPI.src.Services;

public class PointsService : IPointsService
{
    private readonly IPointsRepo _pointsRepo;
    
    public PointsService(IPointsRepo pointsRepo)
    {
        _pointsRepo = pointsRepo;
    }

    public async Task<List<Point>> GetAllPoints()
    {
        return await _pointsRepo.GetAllPoints();
    }

    public async Task<Point> GetPointById(int id)
    {
        return await _pointsRepo.GetPointById(id);
    }

    public async Task<Point> GetPointByCoordinates(int x, int y)
    {
        return await _pointsRepo.GetPointByCoordinates(x, y);
    }

    public async Task<Point> AddPoint(PointDTO pointDto)
    {
        var point = new Point
        {
            X = pointDto.X,
            Y = pointDto.Y
        };
        return await _pointsRepo.AddPoint(point);
    }

    public async Task<List<Point>> AddPoints(List<PointDTO> pointsDto)
    {
        var points = pointsDto.Select(p => new Point
        {
            X = p.X,
            Y = p.Y
        }).ToList();
        return await _pointsRepo.AddPoints(points);
    }

    public async Task<bool> DeletePoint(int id)
    {
        return await _pointsRepo.DeletePoint(id);
    }

    public async Task<bool> DeletePointByCoordinates(int x, int y)
    {
        return await _pointsRepo.DeletePointByCoordinates(x, y);
    }
}

using SquaresAPI.src.Models;
using SquaresAPI.src.DTOs;

namespace SquaresAPI.src.Repositories;

public class PointsRepository : IPointsRepository
{
    private readonly List<Point> _points;

    public PointsRepository()
    {
        _points = new List<Point>();
    }

    public Task<List<Point>> GetAllPoints()
    {
        return Task.FromResult(_points.ToList());
    }

    public Task<Point?> GetPointByCoordinates(int x, int y)
    {
        var point = _points.FirstOrDefault(p => p.X == x && p.Y == y);
        return Task.FromResult(point);
    }

    public Task<Point> AddPoint(Point point)
    {
        _points.Add(point);
        if (_points.Any(p => p.X == point.X && p.Y == point.Y))
        {
            throw new InvalidOperationException($"Point with coordinates ({point.X}, {point.Y}) already exists.");
        }
        return Task.FromResult(point);
    }

    public Task<BatchInsertionResult> AddPoints(List<Point> points)
    {
        List<Point> addedPoints = new List<Point>();
        List<Point> duplicatePoints = new List<Point>();

        foreach (var point in points)
        {
            if (_points.Any(p => p.X == point.X && p.Y == point.Y))
            { 
                duplicatePoints.Add(point);
                continue;
            }
            _points.Add(point);
            addedPoints.Add(point);
        }
        return Task.FromResult(new BatchInsertionResult
        {
            AddedPoints = addedPoints,
            DuplicatePoints = duplicatePoints
        });
    }

    public Task<bool> DeletePointByCoordinates(int x, int y)
    {
        var point = _points.FirstOrDefault(p => p.X == x && p.Y == y);
        if (point != null)
        {
            _points.Remove(point);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}

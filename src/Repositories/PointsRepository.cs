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

    public async Task<List<Point>> GetAllPoints()
    {
        return await Task.FromResult(_points.ToList());
    }

    public async Task<Point?> GetPointByCoordinates(int x, int y)
    {
        var point = _points.FirstOrDefault(p => p.X == x && p.Y == y);
        return await Task.FromResult(point);
    }

    public async Task<Point> AddPoint(Point point)
    {
        if (_points.Any(p => p.X == point.X && p.Y == point.Y))
        {
            throw new InvalidOperationException("Point with the same coordinates already exists.");
        }
        _points.Add(point);
        return await Task.FromResult(point);
    }

    public async Task<BatchInsertionResult> AddPoints(List<Point> points)
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
        return await Task.FromResult(new BatchInsertionResult
        {
            AddedPoints = addedPoints,
            DuplicatePoints = duplicatePoints
        });
    }

    public async Task<bool> DeletePointByCoordinates(int x, int y)
    {
        var point = _points.FirstOrDefault(p => p.X == x && p.Y == y);
        if (point != null)
        {
            _points.Remove(point);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}

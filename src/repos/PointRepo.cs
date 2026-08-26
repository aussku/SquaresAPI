using SquaresAPI.src.Models;

public class PointRepo : IPointRepo
{
    private readonly List<Point> _points;

    public PointRepo()
    {
        _points = new List<Point>();
    }

    public async Task<List<Point>> GetAllPoints()
    {
        return await Task.FromResult(_points);
    }

    public async Task<Point> GetPointById(int id)
    {
        var point = _points.FirstOrDefault(p => p.Id == id);
        return await Task.FromResult(point);
    }

    public async Task<Point> GetPointByCoordinates(int x, int y)
    {
        var point = _points.FirstOrDefault(p => p.X == x && p.Y == y);
        return await Task.FromResult(point);
    }

    public async Task<Point> AddPoint(Point point)
    {
        point.Id = _points.Count + 1; // Simple auto-increment logic
        _points.Add(point);
        return await Task.FromResult(point);
    }

    public async Task<List<Point>> AddPoints(List<Point> points)
    {
        foreach (var point in points)
        {
            point.Id = _points.Count + 1; // Simple auto-increment logic
            _points.Add(point);
        }
        return await Task.FromResult(points);
    }

    public async Task<bool> DeletePoint(int id)
    {
        var point = _points.FirstOrDefault(p => p.Id == id);
        if (point != null)
        {
            _points.Remove(point);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
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
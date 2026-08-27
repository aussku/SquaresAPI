using SquaresAPI.src.DTOs;
using SquaresAPI.src.Models;
using SquaresAPI.src.Repositories;

namespace SquaresAPI.src.Services;

public class PointsService : IPointsService
{
    private readonly IPointsRepository _pointsRepository;
    
    public PointsService(IPointsRepository pointsRepository)
    {
        _pointsRepository = pointsRepository;
    }

    public async Task<List<Point>> GetAllPoints()
    {
        return await _pointsRepository.GetAllPoints();
    }

    public async Task<Point?> GetPointByCoordinates(int x, int y)
    {
        return await _pointsRepository.GetPointByCoordinates(x, y);
    }

    public async Task<Point> AddPoint(PointDTO pointDto)
    {
        var point = new Point(pointDto.X, pointDto.Y);
        return await _pointsRepository.AddPoint(point);
    }

    public async Task<BatchInsertionResult> AddPoints(List<PointDTO> pointsDto)
    {
        var points = pointsDto
        .Select(p => new Point(p.X, p.Y))
        .ToList();
        return await _pointsRepository.AddPoints(points);
    }

    public async Task<bool> DeletePointByCoordinates(int x, int y)
    {
        return await _pointsRepository.DeletePointByCoordinates(x, y);
    }

    public async Task<List<Square>> GetAllSquares()
    {
        List<Point> points = await _pointsRepository.GetAllPoints();
        HashSet<(int, int)> pointSet = points
        .Select(p => (p.X, p.Y))
        .ToHashSet();
        Point[] pointArray = points.ToArray();
        List<Square> squares = new List<Square>();

        for (int i = 0; i < pointArray.Length; i++)
        {
            for (int j = i + 1; j < pointArray.Length; j++)
            {
                Point p1 = pointArray[i];
                Point p2 = pointArray[j];

                int distanceX = p2.X - p1.X;
                int distanceY = p2.Y - p1.Y;
                
                // Rotate p1 and p2 by 90 degrees to find other two possible points of the square
                Point p3 = new Point(p1.X - distanceY, p1.Y + distanceX);
                Point p4 = new Point(p2.X - distanceY, p2.Y + distanceX);

                if (pointSet.Contains((p3.X, p3.Y)) && pointSet.Contains((p4.X, p4.Y))) // Check if the other two points exist in the set
                {
                    Square square = new Square(p1, p2, p3, p4);
                    squares.Add(new Square(p1, p2, p3, p4));
                }

                // Rotate p1 and p2 by -90 degrees to find other two possible points of the square
                Point p5 = new Point(p1.X + distanceY, p1.Y - distanceX);
                Point p6 = new Point(p2.X + distanceY, p2.Y - distanceX);

                if (pointSet.Contains((p5.X, p5.Y)) && pointSet.Contains((p6.X, p6.Y)))
                {
                    squares.Add(new Square(p1, p2, p5, p6));
                }
            }
        }
        return squares;
    }

    public async Task<int> GetSquareCount()
    {
        List<Square> squares = await GetAllSquares();
        return squares.Count;
    }
}

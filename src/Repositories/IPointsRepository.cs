using SquaresAPI.src.Models;
using SquaresAPI.src.DTOs;

namespace SquaresAPI.src.Repositories;

public interface IPointsRepository
{
    Task<List<Point>> GetAllPoints();
    Task<Point?> GetPointByCoordinates(int x, int y);
    Task<Point> AddPoint(Point point);
    Task<BatchInsertionResult> AddPoints(List<Point> points);
    Task<bool> DeletePointByCoordinates(int x, int y);
}

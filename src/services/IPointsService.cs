using SquaresAPI.src.DTOs;
using SquaresAPI.src.Models;

namespace SquaresAPI.src.Services;

public interface IPointsService
{
    Task<List<Point>> GetAllPoints();
    Task<Point?> GetPointByCoordinates(int x, int y);
    Task<Point> AddPoint(PointDTO point);
    Task<BatchInsertionResult> AddPoints(List<PointDTO> points);
    Task<bool> DeletePointByCoordinates(int x, int y);
    Task<List<Square>> GetAllSquares();
    Task<int> GetSquareCount();
}

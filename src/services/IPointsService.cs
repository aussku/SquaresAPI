using SquaresAPI.src.DTOs;
using SquaresAPI.src.Models;

namespace SquaresAPI.src.Services;

public interface IPointsService
{
    Task<List<Point>> GetAllPoints();
    Task<Point> GetPointById(int id);
    Task<Point> GetPointByCoordinates(int x, int y);
    Task<Point> AddPoint(PointDTO point);
    Task<List<Point>> AddPoints(List<PointDTO> points);
    Task<bool> DeletePoint(int id);
    Task<bool> DeletePointByCoordinates(int x, int y);
}

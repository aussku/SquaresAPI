using SquaresAPI.src.Models;

public interface IPointRepo
{
    Task<List<Point>> GetAllPoints();
    Task<Point> GetPointById(int id);
    Task<Point> GetPointByCoordinates(int x, int y);
    Task<Point> AddPoint(Point point);
    Task<List<Point>> AddPoints(List<Point> points);
    Task<bool> DeletePoint(int id);
    Task<bool> DeletePointByCoordinates(int x, int y);
}
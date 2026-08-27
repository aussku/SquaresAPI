using SquaresAPI.src.Models;

namespace SquaresAPI.src.DTOs;

public class BatchInsertionResult
{
    public List<Point> AddedPoints { get; set; } = [];
    public List<Point> DuplicatePoints { get; set; } = [];
}
using SquaresAPI.src.DTOs;
using SquaresAPI.src.Models;
using SquaresAPI.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace SquaresAPI.src.Controllers;

[ApiController]
[Route("api/points")]
public class PointController : ControllerBase
{
    private readonly IPointsService _pointsService;

    public PointController(IPointsService pointsService)
    {
        _pointsService = pointsService;
    }

    [HttpGet]
    public ActionResult<List<Point>> GetAllPoints()
    {
        List<Point> points = _pointsService.GetAllPoints().Result;
        return Ok(points);
    }

    [HttpGet("{x}/{y}")]
    public ActionResult<Point> GetPointByCoordinates(int x, int y)
    {
        Point? point = _pointsService.GetPointByCoordinates(x, y).Result;
        if (point is null)
        {
            return NotFound();
        }
        return Ok(point);
    }

    [HttpPost]
    public ActionResult<Point> AddPoint(PointDTO pointDto)
    {
        Point point = _pointsService.AddPoint(pointDto).Result;
        return CreatedAtAction(nameof(GetPointByCoordinates), new { x = point.X, y = point.Y }, point);
    }
    
    [HttpPost("batch")]
    public ActionResult<List<Point>> AddPoints(List<PointDTO> pointsDto)
    {
        List<Point> points = _pointsService.AddPoints(pointsDto).Result;
        return CreatedAtAction(nameof(GetAllPoints), points);
    }

    [HttpDelete("{x}/{y}")]
    public ActionResult DeletePointByCoordinates(int x, int y)
    {
        bool deleted = _pointsService.DeletePointByCoordinates(x, y).Result;
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}

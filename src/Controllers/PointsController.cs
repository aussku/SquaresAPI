using SquaresAPI.src.DTOs;
using SquaresAPI.src.Models;
using SquaresAPI.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace SquaresAPI.src.Controllers;

[ApiController]
[Route("api/points")]
public class PointsController : ControllerBase
{
    private readonly IPointsService _pointsService;

    public PointsController(IPointsService pointsService)
    {
        _pointsService = pointsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Point>>> GetAllPoints()
    {
        var points = await _pointsService.GetAllPoints();
        return Ok(points);
    }

    [HttpGet("{x}/{y}")]
    public async Task<ActionResult<Point>> GetPointByCoordinates(int x, int y)
    {
        var point = await _pointsService.GetPointByCoordinates(x, y);
        if (point is null)
        {
            return NotFound();
        }
        return Ok(point);
    }

    [HttpPost]
    public async Task<ActionResult<Point>> AddPoint(PointDTO pointDto)
    {
        var point = await _pointsService.AddPoint(pointDto);
        return CreatedAtAction(nameof(GetPointByCoordinates), new { x = point.X, y = point.Y }, point);
    }
    
    [HttpPost("batch")]
    public async Task<ActionResult<BatchInsertionResult>> AddPoints(List<PointDTO> pointsDto)
    {
        var result = await _pointsService.AddPoints(pointsDto);
        return Ok(result);
    }

    [HttpDelete("{x}/{y}")]
    public async Task<ActionResult> DeletePointByCoordinates(int x, int y)
    {
        bool deleted = await _pointsService.DeletePointByCoordinates(x, y);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("squares")]
    public async Task<ActionResult<List<Square>>> GetAllSquares()
    {
        var squares = await _pointsService.GetAllSquares();
        return Ok(squares);
    }

    [HttpGet("squares/count")]
    public async Task<ActionResult<int>> GetSquareCount()
    {
        int count = await _pointsService.GetSquareCount();
        return Ok(count); 
    }
}

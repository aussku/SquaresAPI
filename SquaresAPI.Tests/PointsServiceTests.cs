using SquaresAPI.src.Services;
using SquaresAPI.src.Repositories;
using SquaresAPI.src.Models;
using NUnit.Framework;

namespace SquaresAPI.Tests;

[TestFixture]
public class PointsServiceTests
{
    private PointsRepository _repository = null!;
    private PointsService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _repository = new PointsRepository();
        _service = new PointsService(_repository);
    }

    [Test]
    public async Task GetAllSquares_NoPoints_ReturnsEmpty()
    {
        var squares = await _service.GetAllSquares();

        Assert.That(squares, Is.Empty);
    }

    [Test]
    public async Task GetAllSquares_ReturnsOneSquare()
    {
        await _repository.AddPoints(new List<Point>
        {
            new Point(0, 0),
            new Point(1, 0),
            new Point(1, 1),
            new Point(0, 1)
        });

        var squares = await _service.GetAllSquares();

        Assert.That(squares, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task GetSquareCount_TwoSquares_ReturnsTwo()
    {
        await _repository.AddPoints(new List<Point>
        {
            new Point(-1, 3),
            new Point(-1, 1),
            new Point(1, 3),
            new Point(1, 1),

            new Point(-1, -1),
            new Point(3, -1),
            new Point(3, 3),
        });

        var count = await _service.GetSquareCount();

        Assert.That(count, Is.EqualTo(2));
    }
}
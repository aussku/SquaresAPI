using SquaresAPI.src.Repositories;
using SquaresAPI.src.Models;
using NUnit.Framework;

namespace SquaresAPI.Tests;

[TestFixture]
public class PointsRepositoryTests
{
    private PointsRepository _repository = null!;

    [SetUp]
    public void SetUp()
    {
        _repository = new PointsRepository();
    }

    [Test]
    public async Task AddPoint_GetPoint_ReturnsAddedPoint()
    {
        var point = new Point(1, 2);
        await _repository.AddPoint(point);

        var newPoint = await _repository.GetPointByCoordinates(1, 2);

        Assert.That(newPoint, Is.EqualTo(point));
    }

    [Test]
    public async Task AddPoints_GetAllPoints_ReturnsAddedPoints()
    {
        var points = new List<Point>
        {
            new Point(1, 2),
            new Point(3, 4),
            new Point(5, 6)
        };

        await _repository.AddPoints(points);

        var allPoints = await _repository.GetAllPoints();

        Assert.That(allPoints, Is.EquivalentTo(points));
    }

    [Test]
    public async Task GetPointByCoordinates_PointDoesNotExist_ReturnsNull()
    {
        var point = await _repository.GetPointByCoordinates(10, 20);

        Assert.That(point, Is.Null);
    }

    [Test]
    public async Task GetAllPoints_NoPoints_ReturnsEmpty()
    {
        var allPoints = await _repository.GetAllPoints();

        Assert.That(allPoints, Is.Empty);
    }

    [Test]
    public async Task DeletePointByCoordinates_PointExists_DeletesPoint()
    {
        var point = new Point(1, 2);
        await _repository.AddPoint(point);

        await _repository.DeletePointByCoordinates(1, 2);

        var deletedPoint = await _repository.GetPointByCoordinates(1, 2);
        Assert.That(deletedPoint, Is.Null);
    }

    [Test]
    public async Task DeletePointByCoordinates_PointDoesNotExist_DoesNothing()
    {
        var deleted = await _repository.DeletePointByCoordinates(10, 20);

        Assert.That(deleted, Is.False);
    }

    [Test]
    public async Task AddPoints_DuplicatePoints_IgnoresDuplicates()
    {
        var points = new List<Point>
        {
            new Point(1, 2),
            new Point(3, 4),
            new Point(1, 2) // Duplicate point
        };

        await _repository.AddPoints(points);

        var allPoints = await _repository.GetAllPoints();

        Assert.That(allPoints, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task AddPoint_DuplicatePoint_ThrowsInvalidOperationException()
    {
        var point = new Point(1, 2);
        await _repository.AddPoint(point);

        Assert.ThrowsAsync<InvalidOperationException>(async () => await _repository.AddPoint(point));

        var allPoints = await _repository.GetAllPoints();
        Assert.That(allPoints, Has.Count.EqualTo(1));
    }
}
# SquaresAPI

This API helps detect all possible squares by points (X and Y coordinates) in a 2D plane.

## Features

- add a list of points
- add a single point
- delete a point
- retrieve identified squares

## Objects

### Point

A point represents a coordinate on a 2D plane.

```json
{
  "x": 1,
  "y": 2
}
```

### Square

A square consists of four points.

```json
{
  "points": [
    { "x": 0, "y": 0 },
    { "x": 1, "y": 0 },
    { "x": 1, "y": 1 },
    { "x": 0, "y": 1 }
  ]
}
```

## API Endpoints

- `GET /api/points` get all points
- `GET /api/points/{x}/{y}` retrieve a point by coordinates
- `POST /api/points` add a point
- `POST /api/points/batch` add multiple points
- `DELETE /api/points/{x}/{y}` delete a point
- `GET /api/points/squares` retrieve all squares
- `GET /api/points/squares/count` retrieve the number of squares

## Testing

The API was manually tested using Postman.

Automated tests were implemented using NUnit.

Tests can be run with:

```bash
dotnet test SquaresAPI.Tests/SquaresAPI.Tests.csproj
```

## Tech stack

- .NET 8
- ASP.NET Core Web API
- C#
- NUnit
- Postman
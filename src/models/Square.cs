namespace SquaresAPI.src.Models;

public class Square
{
    public List<Point> Points { get; }
    
    public Square(Point pt1, Point pt2, Point pt3, Point pt4)
    {
        Points = new List<Point> { pt1, pt2, pt3, pt4 };
    }
}

namespace Geometry.Domain.Entities
{
    public class Segment
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
        }
    }
}

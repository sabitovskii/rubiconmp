namespace Geometry.App.DTOs
{
    public class PointDto
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointDto() { }

        public PointDto(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

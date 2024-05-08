using Geometry.Domain.Entities;

namespace Geometry.App.DTOs
{
    public class RectangleDto : BaseDto
    {
        public PointDto A { get; set; }
        public PointDto B { get; set; }
        public PointDto C { get; set; }
        public PointDto D { get; set; }
    }
}

using Geometry.API.Models.Common;

namespace Geometry.API.Models.Responses
{
    public class RectangleResponse : ResponseBase
    {
        public Point A {  get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
    }
}

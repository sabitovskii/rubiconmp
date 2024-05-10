using Geometry.API.Models.Common;

namespace Geometry.API.Models.Requests
{
    public class GetIntersectingRectanglesRequest
    {
        public Point Start {  get; set; }
        public Point End { get; set; }
    }
}

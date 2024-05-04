using Geometry.Domain.Entities;

namespace Geometry.App.Interfaces
{
    public interface ISegmentService
    {
        bool IsIntersectingSegment(Segment segment);
    }
}

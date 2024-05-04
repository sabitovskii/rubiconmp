using Geometry.Domain.Entities;

namespace Geometry.Domain.Interfaces
{
    public interface ISegmentRepository
    {
        Segment CreateAsync(Segment segment);
        IReadOnlyList<Segment> GetAllAsync();
        bool IsIntersectingSegment(Segment segment);
    }
}

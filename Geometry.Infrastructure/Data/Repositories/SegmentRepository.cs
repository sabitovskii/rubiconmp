using Geometry.Domain.Entities;
using Geometry.Domain.Interfaces;

namespace Geometry.Infrastructure.Data.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        public Segment CreateAsync(Segment segment)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Segment> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsIntersectingSegment(Segment segment)
        {
            throw new NotImplementedException();
        }
    }
}

using Geometry.App.DTOs;

namespace Geometry.App.Interfaces
{
    public interface IRectangleService
    {
        Task<RectangleDto> CreateAsync(RectangleDto rectangleDto);
        Task<IReadOnlyList<RectangleDto>> GetIntersectingListAsync(SegmentDto segmentDto);
    }
}

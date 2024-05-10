using Geometry.Domain.Entities;

namespace Geometry.Domain.Interfaces
{
    public interface IRectangleRepository
    {
        Task<IReadOnlyCollection<Rectangle>> GetBatchAsync(int skip, int batchSize);
        Task<Rectangle> CreateAsync(Rectangle rectangle);
    }
}

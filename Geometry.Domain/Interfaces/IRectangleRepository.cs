using Geometry.Domain.Entities;

namespace Geometry.Domain.Interfaces
{
    public interface IRectangleRepository
    {
        Task<IReadOnlyCollection<Rectangle>> GetAllAsync();
        Task<Rectangle> CreateAsync(Rectangle rectangle);
    }
}

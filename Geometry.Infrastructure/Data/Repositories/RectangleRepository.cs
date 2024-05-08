using Geometry.Domain.Entities;
using Geometry.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Geometry.Infrastructure.Data.Repositories
{
    public class RectangleRepository : IRectangleRepository
    {
        private readonly GeometryDbContext _context;

        public RectangleRepository(GeometryDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Rectangle>> GetAllAsync()
        {
            return await _context.Rectangles.ToListAsync();
        }

        public async Task<Rectangle> CreateAsync(Rectangle rectangle)
        {
            var result = await _context.Rectangles.AddAsync(rectangle);
            return result.Entity;
        }
    }
}

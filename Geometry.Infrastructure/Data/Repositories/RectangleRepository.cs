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

        public async Task<IReadOnlyCollection<Rectangle>> GetBatchAsync(int skip, int batchSize)
        {
            return await _context.Rectangles
                            .OrderBy(r => r.Id)
                            .Skip(skip)
                            .Take(batchSize)
                            .ToListAsync();
        }

        public async Task<Rectangle> CreateAsync(Rectangle rectangle)
        {
            var result = await _context.Rectangles.AddAsync(rectangle);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}

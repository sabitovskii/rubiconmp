using Geometry.Domain.Entities;
using Geometry.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Geometry.Infrastructure.Data
{
    public class GeometryDbContext : DbContext
    {
        public GeometryDbContext(DbContextOptions<GeometryDbContext> options) : base(options)
        {
            
        }

        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<Segment> Segments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RectangleConfiguration());
            modelBuilder.ApplyConfiguration(new SegmentConfiguration());
        }
    }
}

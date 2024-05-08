using Geometry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geometry.Infrastructure.Data.Configurations
{
    public class RectangleConfiguration : IEntityTypeConfiguration<Rectangle>
    {
        public void Configure(EntityTypeBuilder<Rectangle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.A);
            builder.OwnsOne(x => x.B);
            builder.OwnsOne(x => x.C);
            builder.OwnsOne(x => x.D);
        }
    }
}

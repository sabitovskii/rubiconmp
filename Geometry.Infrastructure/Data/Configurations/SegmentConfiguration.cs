using Geometry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geometry.Infrastructure.Data.Configurations
{
    public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Start);
            builder.OwnsOne(x => x.End);
        }
    }
}

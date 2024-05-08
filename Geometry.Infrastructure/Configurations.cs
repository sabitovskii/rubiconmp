using Geometry.App.Interfaces;
using Geometry.Domain.Interfaces;
using Geometry.Infrastructure.Data;
using Geometry.Infrastructure.Data.Repositories;
using Geometry.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Geometry.Infrastructure
{
    public static class Configurations
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GeometryDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IRectangleRepository, RectangleRepository>();
            services.AddScoped<ISegmentRepository, SegmentRepository>();

            services.AddScoped<IRectangleService, RectangleService>();
            services.AddScoped<ISegmentService, SegmentService>();

            return services;
        }
    }
}

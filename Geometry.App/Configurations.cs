using FluentValidation;
using Geometry.App.DTOs;
using Geometry.App.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Geometry.App
{
    public static class Configurations
    {
        public static IServiceCollection AddDtoValidations(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RectangleDto>, RectangleValidator>();

            return services;
        }
    }
}

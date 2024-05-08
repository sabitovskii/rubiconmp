using FluentValidation;
using Geometry.App;
using Geometry.App.DTOs;
using Geometry.App.Interfaces;
using Geometry.Domain.Interfaces;

namespace Geometry.Infrastructure.Services
{
    public class RectangleService : IRectangleService
    {
        private readonly IRectangleRepository _repository;
        private readonly IValidator<RectangleDto> _validator;

        public RectangleService(IRectangleRepository repository,
                                IValidator<RectangleDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<RectangleDto> CreateAsync(RectangleDto rectangleDto)
        {
            var validationResult = await _validator.ValidateAsync(rectangleDto);
            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.First();

            }
            var entity = rectangleDto.ToEntity();
            var createdEntity = await _repository.CreateAsync(entity);
            return createdEntity.ToDto();
        }
    }
}

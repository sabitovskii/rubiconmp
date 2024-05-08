using FluentValidation;
using Geometry.App.DTOs;

namespace Geometry.App.Validators
{
    public class RectangleValidator : AbstractValidator<RectangleDto>
    {
        public RectangleValidator()
        {
            RuleFor(rectangle => rectangle.A).NotNull().WithMessage("Point A is required.");
            RuleFor(rectangle => rectangle.B).NotNull().WithMessage("Point B is required.");
            RuleFor(rectangle => rectangle.C).NotNull().WithMessage("Point C is required.");
            RuleFor(rectangle => rectangle.D).NotNull().WithMessage("Point D is required.");
        }
    }
}

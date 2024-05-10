using FluentValidation;
using Geometry.App.DTOs;

namespace Geometry.App.Validators
{
    public class RectangleValidator : AbstractValidator<RectangleDto>
    {
        public RectangleValidator()
        {
            // Check a rectangle to have all points set
            RuleFor(rect => rect).Must(HaveValidPoints).WithMessage("Rectangle cannot have an empty point.");

            When(rect => rect.A != null && rect.B != null && rect.C != null && rect.D != null, () =>
            {
                // Check if any points are the same
                RuleFor(rect => rect).Must(HaveDistinctPoints).WithMessage("Rectangle cannot have two points with the same coordinates.");

                // Check lengths for each side of rectangle
                RuleFor(rect => rect).Must(HaveEqualOppositeLengths).WithMessage("Opposite sides of a rectangle are not equal.");

                // Check if sides are perpendicular
                RuleFor(rect => (rect.A.Y - rect.B.Y) * (rect.B.Y - rect.C.Y))
                    .Equal(rect => -1 * (rect.A.X - rect.B.X) * (rect.B.X - rect.C.X))
                    .WithMessage("Rectangle is not perpendicular.");
            });
        }

        private bool HaveEqualOppositeLengths(RectangleDto dto)
        {
            var oppositeSidesAreEqual = dto.A.X - dto.B.X == dto.D.X - dto.C.X &&
                                        dto.A.Y - dto.B.Y == dto.D.Y - dto.C.Y &&
                                        dto.B.X - dto.C.X == dto.A.X - dto.D.X &&
                                        dto.B.Y - dto.C.Y == dto.A.Y - dto.D.Y;
            return oppositeSidesAreEqual;
        }

        private bool HaveValidPoints(RectangleDto dto)
        {
            var anyPointIsNull = dto.A == null ||
                                dto.B == null ||
                                dto.C == null ||
                                dto.D == null;

            return !anyPointIsNull;
        }

        private bool HaveDistinctPoints(RectangleDto dto)
        {
            var anyPointsAreTheSame = dto.A.X == dto.B.X && dto.A.Y == dto.B.Y ||
                                       dto.A.X == dto.C.X && dto.A.Y == dto.C.Y ||
                                       dto.A.X == dto.D.X && dto.A.Y == dto.D.Y ||
                                       dto.B.X == dto.C.X && dto.B.Y == dto.C.Y ||
                                       dto.B.X == dto.D.X && dto.B.Y == dto.D.Y ||
                                       dto.C.X == dto.D.X && dto.C.Y == dto.D.Y;

            return !anyPointsAreTheSame;
        }
    }
}

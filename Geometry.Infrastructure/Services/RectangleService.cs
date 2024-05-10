using FluentValidation;
using Geometry.App;
using Geometry.App.DTOs;
using Geometry.App.Exceptions;
using Geometry.App.Interfaces;
using Geometry.Domain.Entities;
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
                var failure = validationResult.Errors.First();
                var errorMessage = $"Property {failure.PropertyName} failed validation, error: {failure.ErrorMessage}";
                throw new InvalidRectangleException(errorMessage);
            }
            var entity = rectangleDto.ToEntity();
            var createdEntity = await _repository.CreateAsync(entity);
            return createdEntity.ToDto();
        }

        public async Task<IReadOnlyList<RectangleDto>> GetIntersectingListAsync(SegmentDto segmentDto)
        {
            var result = new List<RectangleDto>();
            int skip = 0;
            int batchSize = 100;

            while (true)
            {
                var batch = await _repository.GetBatchAsync(skip, batchSize);
                if (!batch.Any())
                {
                    break;
                }

                var filteredDtos = batch.Where(rect => IsIntersectingSegment(rect, segmentDto))
                                        .Select(rect => rect.ToDto());

                result.AddRange(filteredDtos);
                skip += batchSize;
            }

            return result;
        }

        private bool IsIntersectingSegment(Rectangle rectangle, SegmentDto segmentDto)
        {
            var rect_A = rectangle.A.ToDto();
            var rect_B = rectangle.B.ToDto();
            var rect_C = rectangle.C.ToDto();
            var rect_D = rectangle.D.ToDto();
            var start = segmentDto.Start;
            var end = segmentDto.End;

            if (SegmentsIntersect(rect_A, rect_B, start, end) ||
                SegmentsIntersect(rect_B, rect_C, start, end) ||
                SegmentsIntersect(rect_C, rect_D, start, end) ||
                SegmentsIntersect(rect_D, rect_A, start, end))
                return true;

            return false;
        }

        private bool SegmentsIntersect(PointDto p1, PointDto q1, PointDto p2, PointDto q2)
        {
            double d1 = Direction(p2, q2, p1);
            double d2 = Direction(p2, q2, q1);
            double d3 = Direction(p1, q1, p2);
            double d4 = Direction(p1, q1, q2);

            if (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) &&
                ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0)))
                return true;

            if (d1 == 0 && IsOnSegment(p2, q2, p1)) return true;
            if (d2 == 0 && IsOnSegment(p2, q2, q1)) return true;
            if (d3 == 0 && IsOnSegment(p1, q1, p2)) return true;
            if (d4 == 0 && IsOnSegment(p1, q1, q2)) return true;

            return false;
        }

        private double Direction(PointDto pi, PointDto pj, PointDto pk)
        {
            return (pk.X - pi.X) * (pj.Y - pi.Y) - (pj.X - pi.X) * (pk.Y - pi.Y);
        }

        private bool IsOnSegment(PointDto pi, PointDto pj, PointDto pk)
        {
            return Math.Min(pi.X, pj.X) <= pk.X && pk.X <= Math.Max(pi.X, pj.X) &&
                Math.Min(pi.Y, pj.Y) <= pk.Y && pk.Y <= Math.Max(pi.Y, pj.Y);
        }
    }
}

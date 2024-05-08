using Geometry.App.DTOs;
using Geometry.Domain.Entities;

namespace Geometry.App
{
    public static class Mappings
    {
        public static RectangleDto ToDto(this Rectangle entity)
        {
            RectangleDto dto = new RectangleDto()
            {
                Id = entity.Id,
                A = entity.A.ToDto(),
                B = entity.B.ToDto(),
                C = entity.C.ToDto(),
                D = entity.D.ToDto()
            };
            return dto;
        }

        public static Rectangle ToEntity(this RectangleDto dto)
        {
            Rectangle entity = new Rectangle()
            {
                A = dto.A.ToEntity(),
                B = dto.B.ToEntity(),
                C = dto.C.ToEntity(),
                D = dto.D.ToEntity()
            };

            if (dto.Id != 0)
            {
                entity.Id = dto.Id;
            }

            return entity;
        }

        public static PointDto ToDto(this Point entity)
        {
            PointDto dto = new PointDto()
            {
                X = entity.X,
                Y = entity.Y
            };
            return dto;
        }

        public static Point ToEntity(this PointDto dto)
        {
            Point entity = new Point()
            {
                X = dto.X,
                Y = dto.Y
            };
            return entity;
        }
    }
}

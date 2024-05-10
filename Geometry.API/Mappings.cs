using Geometry.API.Models.Common;
using Geometry.API.Models.Requests;
using Geometry.API.Models.Responses;
using Geometry.App.DTOs;

namespace Geometry.API
{
    public static class Mappings
    {
        public static RectangleDto ToDto(this CreateRectangleRequest request)
        {
            RectangleDto dto = new RectangleDto()
            {
                A = new PointDto(request.A.X, request.A.Y),
                B = new PointDto(request.B.X, request.B.Y),
                C = new PointDto(request.C.X, request.C.Y),
                D = new PointDto(request.D.X, request.D.Y)
            };
            return dto;
        }

        public static RectangleResponse ToResponse(this RectangleDto dto)
        {
            RectangleResponse response = new RectangleResponse()
            {
                Id = dto.Id,
                A = new Point(dto.A.X, dto.A.Y),
                B = new Point(dto.B.X, dto.B.Y),
                C = new Point(dto.C.X, dto.C.Y),
                D = new Point(dto.D.X, dto.D.Y)
            };
            return response;
        }

        public static PointDto ToDto(this Point point)
        {
            return new PointDto(point.X, point.Y) { };
        }

        public static Point ToModel(this PointDto dto)
        {
            return new Point(dto.X, dto.Y);
        }
    }
}

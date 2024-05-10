using Geometry.API.Models.Requests;
using Geometry.API.Models.Responses;
using Geometry.App.DTOs;
using Geometry.App.Exceptions;
using Geometry.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geometry.API.Controllers
{
    [Route("api/rectangles")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly IRectangleService _rectangleService;

        public RectanglesController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        [HttpPost]
        public async Task<ActionResult<RectangleResponse>> CreateRectangleAsync(CreateRectangleRequest request)
        {
            try
            {
                var createdDto = await _rectangleService.CreateAsync(request.ToDto());
                return Ok(createdDto.ToResponse());
            }
            catch (InvalidRectangleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("intersect")]
        public async Task<ActionResult<RectangleResponse>> GetIntersectingRectanglesAsync(
            GetIntersectingRectanglesRequest request)
        {
            var segmentDto = new SegmentDto(request.Start.ToDto(), request.End.ToDto());
            var result = await _rectangleService.GetIntersectingListAsync(segmentDto);
            var response = result.Select(r => r.ToResponse());
            return Ok(response);
        }
    }
}

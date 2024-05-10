namespace Geometry.App.DTOs
{
    public class SegmentDto : BaseDto
    {
        public PointDto Start {  get; set; }
        public PointDto End { get; set; }

        public SegmentDto() { }

        public SegmentDto(PointDto start, PointDto end)
        {
            Start = start;
            End = end;
        }
    }
}

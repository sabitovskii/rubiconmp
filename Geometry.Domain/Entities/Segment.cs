using System.ComponentModel.DataAnnotations;

namespace Geometry.Domain.Entities
{
    public class Segment : Entity
    {
        [Required]
        public Point Start { get; set; }

        [Required]
        public Point End { get; set; }
    }
}

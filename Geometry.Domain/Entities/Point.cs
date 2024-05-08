using System.ComponentModel.DataAnnotations;

namespace Geometry.Domain.Entities
{
    public class Point
    {
        [Required]
        public double X { get; set; }

        [Required]
        public double Y { get; set; }
    }
}

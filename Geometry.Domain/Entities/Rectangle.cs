using System.ComponentModel.DataAnnotations;

namespace Geometry.Domain.Entities
{
    public class Rectangle : Entity
    {
        [Required]
        public Point A { get; set; }

        [Required]
        public Point B { get; set; }

        [Required]
        public Point C { get; set; }

        [Required]
        public Point D { get; set; }
    }
}

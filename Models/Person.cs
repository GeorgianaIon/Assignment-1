using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string Sex { get; set; }
        [Required, MaxLength(150)]
        public string EyeColor { get; set; }
        [Required, MaxLength(150)]
        public string HairColor { get; set; }
        [Required, MaxLength(150)]
        public string LastName { get; set; }
        public float Weight { get; set; }
    }
}
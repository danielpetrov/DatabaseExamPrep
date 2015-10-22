namespace CarsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Manifacturer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]

        public string Name { get; set; }
    }
}

namespace CarsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]

        public string Name { get; set; }
    }
}

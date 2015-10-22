namespace CarsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(11)]

        public string Name { get; set; }

        public TransmissionType Transmission { get; set; }

        
        public ushort Year { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// The car can have one Dealer
        /// One to many connection with Dealer
        /// </summary>
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        /// <summary>
        /// The car can have one Manifacturer
        /// One to many connection with Manifacturer
        /// </summary>
        public int ManifacturerId { get; set; }

        public virtual Manifacturer Manifacturer { get; set; }

    }
}

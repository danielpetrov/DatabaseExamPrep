namespace CarsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manifacturer
    {
        /// <summary>
        /// The Dealer can have many cars
        /// one to many connection with the Cars
        /// </summary>
        private ICollection<Car> cars;

        public Manifacturer()
        {
            this.cars = new HashSet<Car>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]

        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}

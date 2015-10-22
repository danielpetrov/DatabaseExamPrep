namespace CarsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        /// <summary>
        /// Makes data connection one to many with CIty - one dealer has many cityes.
        /// We do the same in City for Dealer if we want many to many
        /// </summary>
        private ICollection<City> cities;

        /// <summary>
        /// The Dealer can have many cars
        /// one to many connection with the Cars
        /// </summary>
        private ICollection<Car> cars;

        public Dealer()
        {
            this.cities = new HashSet<City>();
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}

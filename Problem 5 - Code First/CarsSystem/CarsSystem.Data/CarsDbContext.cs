namespace CarsSystem.Data
{
    using System.Data.Entity;
    using Models;

    class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("CarsSystem")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manifacturer> Manifacturers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }
    }
}

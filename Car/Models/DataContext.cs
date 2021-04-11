using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Advertise> Advertisements { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
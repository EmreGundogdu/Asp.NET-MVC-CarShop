using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var cities = new List<City>()
            {
                new City(){CityName="İstanbul"},
                new City(){CityName="Ankara"},
                new City(){CityName="Eskişehir"}
            };
            foreach (var item in cities)
            {
                context.Cities.Add(item);
            }
            context.SaveChanges();
            var status = new List<Status>()
            {
                new Status() {StatusName="For Rent"},
                new Status() {StatusName="For Sale"}
            };
            foreach (var item in status)
            {
                context.Statuses.Add(item);
            }
            context.SaveChanges();
            var brand = new List<Brand>()
            {
                new Brand(){BrandName="BMW"},
                new Brand(){BrandName="Mercedes"},
                new Brand(){BrandName="Audi"}
            };
            foreach (var item in brand)
            {
                context.Brands.Add(item);
            }
            context.SaveChanges();
            var model = new List<Model>()
            {
                new Model(){ModelName="220i",BrandId=1},
                new Model(){ModelName="830d",BrandId=1},
                new Model(){ModelName="GT",BrandId=2},
                new Model(){ModelName="C",BrandId=2}
            };
            foreach (var item in model)
            {
                context.Models.Add(item);
            }
            context.SaveChanges();
            var advertise = new List<Advertise>()
            {
                new Advertise(){BrandId=1,Description="Comfort Plus Car",AdvertiseNo="a125",Price=22000,Date="11/04/2021",Kilometer=15000,ModelYear=2017,Fuel="Dizel",GearingType="Automatic",StatusId=1,ModelId=1,Username="Emre Gundogdu",CityId=1,Phone="123456"},
                new Advertise(){BrandId=2,Description="Sport Car",AdvertiseNo="a126",Price=42000,Date="11/04/2021",Kilometer=25000,ModelYear=2018,Fuel="Dizel",GearingType="Automatic",StatusId=2,ModelId=2,Username="Emre Gundogdu",CityId=2,Phone="123456"},
                new Advertise(){BrandId=1,Description="Fast Car",AdvertiseNo="a127",Price=52000,Date="11/04/2021",Kilometer=35000,ModelYear=2019,Fuel="Dizel",GearingType="Automatic",StatusId=1,ModelId=3,Username="Emre Gundogdu",CityId=3,Phone="123456"}
            };
            foreach (var item in advertise)
            {
                context.Advertisements.Add(item);
            }
            context.SaveChanges();
            var image = new List<Image>()
            {
                new Image(){ImageName="Bmw2.jpg",AdvertiseId=1},
                new Image(){ImageName="Bmw8.jpg",AdvertiseId=3},
                new Image(){ImageName="MbGT.jpg",AdvertiseId=2},
                new Image(){ImageName="MbC-.jpg",AdvertiseId=4}
            };
            foreach (var item in image)
            {
                context.Images.Add(item);
            }
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class Advertise
    {
        public int AdvertiseId { get; set; }
        public string AdvertiseNo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Date { get; set; }
        public int Kilometer { get; set; }
        public int ModelYear { get; set; }
        public string Fuel { get; set; }
        public string GearingType { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public List<Image> Images { get; set; }
    }
}
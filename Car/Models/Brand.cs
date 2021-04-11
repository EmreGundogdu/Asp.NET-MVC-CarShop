using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Model> Models { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int AdvertiseId { get; set; }
        public virtual Advertise Advertise { get; set; }
    }
}
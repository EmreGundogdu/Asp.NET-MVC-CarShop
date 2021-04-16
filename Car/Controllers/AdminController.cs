using Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Car.Controllers
{
    //[Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult AdvertiseList()
        {
            var advertise = db.Advertisements.Include(i => i.Model).Include(i => i.Status).Include(i => i.City).ToList();
            return View(advertise);
        }
    }
}
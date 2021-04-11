using Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Car.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            var advertise = db.Advertisements.Include(m => m.Model).ToList();
            return View(advertise);
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}
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
        public ActionResult Details(int id)
        {
            var advertise = db.Advertisements.Where(i => i.AdvertiseId == id).Include(m => m.Model).Include(m => m.Status).Include(m => m.City).FirstOrDefault();
            var imgs = db.Images.Where(i => i.AdvertiseId == id).ToList();
            ViewBag.imgs = imgs;
            return View(advertise);
        }
        public PartialViewResult Slider()
        {
            var advertise = db.Advertisements.ToList().Take(5);
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            return PartialView(advertise);
        }
    }
}
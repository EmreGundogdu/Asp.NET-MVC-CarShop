using Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace Car.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayi=1)
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            var advertise = db.Advertisements.Include(m => m.Model).ToList().ToPagedList(sayi,3);
            return View(advertise);
        }
        public ActionResult Search(string q)
        {
            var img = db.Images.ToList();
            ViewBag.imgs = img;
            var search = db.Advertisements.Include(m => m.Model);
            if (!string.IsNullOrEmpty(q))
            {
                search = search.Where(i=>i.Description.Contains(q)||i.Model.ModelName.Contains(q)); 
            }
            return View(search.ToList());
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
        public PartialViewResult PartialFilter()
        {
            ViewBag.brandList = new SelectList(GetBrand(), "BrandId", "BrandName");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName");
            return PartialView();
        }
        public List<Brand> GetBrand()
        {
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }
        public ActionResult GetModel(int brandId)
        {
            List<Model> modelList = db.Models.Where(x => x.BrandId == brandId).ToList();
            ViewBag.modelList = new SelectList(modelList, "ModelId", "ModelName");
            return PartialView("ModelPartial");
        }
        public ActionResult Filter(int min,int max,int cityId,int statusId,int brandId,int modelId)
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            var filter = db.Advertisements.Where(i => i.Price >= min && i.Price <= max && i.CityId == cityId && i.StatusId == statusId && i.BrandId == brandId && i.ModelId == modelId).Include(m => m.Model).Include(m => m.Status).Include(m => m.City).ToList();

            return View(filter);
        }
        public ActionResult MenuFilter(int id)
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            var filter = db.Advertisements.Where(i => i.StatusId == id).Include(m => m.Model).Include(m => m.City).Include(m => m.Status).ToList();
            return View(filter);
        }
    }
}
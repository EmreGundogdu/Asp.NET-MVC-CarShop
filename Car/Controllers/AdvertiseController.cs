using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car.Models;

namespace Car.Controllers
{
    public class AdvertiseController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Advertise
        public ActionResult Index()
        {
            var advertisements = db.Advertisements.Include(a => a.City).Include(a => a.Model).Include(a => a.Status);
            return View(advertisements.ToList());
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

        // GET: Advertise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertisements.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // GET: Advertise/Create
        public ActionResult Create()
        {
            ViewBag.brandList = new SelectList(GetBrand(), "BrandId", "BrandName");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName");
            return View();
        }

        // POST: Advertise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvertiseId,AdvertiseNo,Description,Price,Date,Kilometer,ModelYear,Fuel,GearingType,Username,Phone,StatusId,BrandId,ModelId,CityId")] Advertise advertise)
        {
            if (ModelState.IsValid)
            {
                advertise.Username = User.Identity.Name;
                db.Advertisements.Add(advertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", advertise.CityId);
            ViewBag.brandList = new SelectList(GetBrand(), "BrandId", "BrandName");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", advertise.StatusId);
            return View(advertise);
        }

        // GET: Advertise/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertisements.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", advertise.CityId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", advertise.ModelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", advertise.StatusId);
            return View(advertise);
        }

        // POST: Advertise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvertiseId,AdvertiseNo,Description,Price,Date,Kilometer,ModelYear,Fuel,GearingType,Username,Phone,StatusId,BrandId,ModelId,CityId")] Advertise advertise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", advertise.CityId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", advertise.ModelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", advertise.StatusId);
            return View(advertise);
        }

        // GET: Advertise/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertisements.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // POST: Advertise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertise advertise = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

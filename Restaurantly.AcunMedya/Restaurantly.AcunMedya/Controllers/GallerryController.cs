using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;
using Restaurantly.AcunMedya.Entities;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class GallerryController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();

        public ActionResult Index()
        {
            var values = db.Galleries.ToList(); 
            return View(values);
        }
        [HttpGet]
        public ActionResult AddGallerry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGallerry(Gallery p)
        {
            db.Galleries.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GallerryEdit(int id)
        {
            var value = db.Galleries.Find(id);
            return View("GallerryEdit", value);
        }
        [HttpPost]
        public ActionResult GallerryEdit (Gallery p)
        {
            var value = db.Galleries.Find(p.GalleryId);
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GallerryDelete(int id)
        {
            var value = db.Galleries.Find(id);
            db.Galleries.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class SpecialsController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Specials
        public ActionResult Index()
        {
            var values = db.Specials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSpecial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSpecial(Entities.Special p)
        {
            db.Specials.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SpecialEdit(int id)
        {
            var value = db.Specials.Find(id);
            return View("SpecialEdit", value);
        }
        [HttpPost]
        public ActionResult SpecialEdit(Entities.Special p)
        {
            var value = db.Specials.Find(p.SpecialId);
            value.ImageUrl = p.ImageUrl;
            value.FullDescription = p.FullDescription;  
            value.ShortDescription = p.ShortDescription;    
            value.Title = p.Title;  

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SpecialDelete(int id)
        {
            var value = db.Specials.Find(id);
            db.Specials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
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

    public class AboutController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: About
        public ActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
        public ActionResult About()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            db.Abouts.Add(p);
            db.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpGet]
        public ActionResult AboutEdit(int id)
        {
            var value = db.Abouts.Find(id);
            return View("AboutEdit", value);
        }
        [HttpPost]
        public ActionResult AboutEdit(About p)
        {
            var value = db.Abouts.Find(p.AboutId);
            value.Title = p.Title;
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("About");
        }
        public ActionResult AboutDelete(int id)
        {
            var value = db.Abouts.Find(id);
            db.Abouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("About");
        }
    }
}
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
    public class ChefController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Chef
        public ActionResult Index()
        {
            var values = db.Chefs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChef(Chef p)
        {
            db.Chefs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ChefEdit(int id)
        {
            var value = db.Chefs.Find(id);
            return View("ChefEdit", value);
        }
        [HttpPost]
        public ActionResult ChefEdit(Chef p)
        {
            var value = db.Chefs.Find(p.ChefId);
            value.Name = p.Name;
            value.Title = p.Title;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChefDelete(int id)
        {
            var value = db.Chefs.Find(id);
            db.Chefs.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
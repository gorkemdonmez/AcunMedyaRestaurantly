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
    public class ServiceController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Service
        public ActionResult Index()
        {
            var values = db.Serviceses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Entities.Services p)
        {
            db.Serviceses.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ServiceEdit(int id)
        {
            var value = db.Serviceses.Find(id);
            return View("ServiceEdit", value);
        }
        [HttpPost]
        public ActionResult ServiceEdit(Services p)
        {
            var value = db.Serviceses.Find(p.ServicesId);
            value.Title = p.Title;
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ServiceDelete(int id)
        {
            var value = db.Serviceses.Find(id);
            db.Serviceses.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
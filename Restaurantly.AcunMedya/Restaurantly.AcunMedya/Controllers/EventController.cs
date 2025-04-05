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

    public class EventController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();

        public ActionResult Index()
        {
            var values = db.Events.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(Events p)
        {
            db.Events.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EventEdit(int id)
        {
            var value = db.Events.Find(id);
            return View("EventEdit", value);
        }
        [HttpPost]
        public ActionResult EventEdit(Events p)
        {
            var value = db.Events.Find(p.EventId);
            value.Title = p.Title;
            value.Img = p.Img;
            value.Price = p.Price;
            value.Desc2 = p.Desc2;
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EventDelete(int id)
        {
            var value = db.Events.Find(id);
            db.Events.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
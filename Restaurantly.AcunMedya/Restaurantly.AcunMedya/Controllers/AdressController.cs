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
    public class AdressController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext(); 
        // GET: Adress
        public ActionResult Index()
        {
            var values = db.Adresses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdress(Adres p) 
        {
            db.Adresses.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdressEdit(int id)
        {
            var value = db.Adresses.Find(id);
            return View("AdressEdit", value);
        }
        [HttpPost]
        public ActionResult AdressEdit(Adres p)
        {
            var value = db.Adresses.Find(p.AdresId);
            value.Location = p.Location;
            value.OpenHours = p.OpenHours;
            value.Email = p.Email;
            value.Call = p.Call;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdressDelete(int id)
        {
            var value = db.Adresses.Find(id);
            db.Adresses.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
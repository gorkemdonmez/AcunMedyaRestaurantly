using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext(); 
        // GET: Reservation
        public ActionResult Index()
        {
            var values = db.Reservations.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddReservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReservation(Entities.Reservation p)
        {
            db.Reservations.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {
            var value = db.Reservations.Find(id);
            return View("ReservationEdit", value);
        }
        [HttpPost]
        public ActionResult ReservationEdit(Entities.Reservation p)
        {
            var value = db.Reservations.Find(p.ReservationId);
            value.Name = p.Name;
            value.Email = p.Email;
            value.Phone = p.Phone;
            value.ReservationDate = p.ReservationDate;
            value.Time = p.Time;
            value.ReservationStatus = p.ReservationStatus;
            value.GuestCount = p.GuestCount;
            value.Description = p.Description;   
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReservationDelete(int id)
        {
            var value = db.Reservations.Find(id);
            db.Reservations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReservationDetails(int id)
        {
            var value = db.Reservations.Find(id);
            value.ReservationStatus = "Onaylandı";

            db.SaveChanges();
            return View("ReservationDetails", value);
        }
       
    }
}
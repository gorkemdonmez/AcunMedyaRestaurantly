using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;
using Restaurantly.AcunMedya.Entities;

namespace Restaurantly.AcunMedya.Controllers
{
    public class DefaultController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialTop()
        {
            ViewBag.Call = Db.Adresses.Select(x=>x.Call).FirstOrDefault();
            ViewBag.Openhour = Db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.SubTitle = Db.Features.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.Title = Db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl = Db.Features.Select(x => x.VideoUrl).FirstOrDefault();

            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Description = Db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.Title = Db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.ImageUrl = Db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var values = Db.Serviceses.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialMenu()
        {
            var values = Db.Products.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model)
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            Db.Contacts.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Mesajınız alınmıştır. Teşekkür ederiz.";
            return View("Index");
        }
        public PartialViewResult PartialSpecial()
        {
            var values = Db.Specials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialBook()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookAdd(Reservation model)
        {
            model.ReservationDate = DateTime.Now;
            Db.Reservations.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Rezervasyonunuz alınmıştır. Teşekkür ederiz.";
            return View("Index");
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = Db.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialChefs()
        {
           var values = Db.Chefs.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialGallery()
        {
            var values = Db.Products.ToList();  
            return PartialView(values);
        }
        public PartialViewResult PartialAdress()
        {
            ViewBag.location = Db.Adresses.Select(x => x.Location).FirstOrDefault();
            ViewBag.Call = Db.Adresses.Select(x => x.Call).FirstOrDefault();
            ViewBag.Openhour = Db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            ViewBag.Email = Db.Adresses.Select(x => x.Email).FirstOrDefault();
            return PartialView();
        }
       public PartialViewResult PartialEvent()
        {
            var values = Db.Events.ToList();
            return PartialView(values);
        }
       
    }
}
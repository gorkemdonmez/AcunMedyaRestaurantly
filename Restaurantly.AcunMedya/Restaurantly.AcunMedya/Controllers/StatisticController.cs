using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    public class StatisticController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.AdminCount = db.Admins.Count(); 
            ViewBag.SpecialCount = db.Specials.Count();
            ViewBag.ChefCount = db.Chefs.Count();
            ViewBag.AboutCount = db.Abouts.Count();
            ViewBag.AdressCount = db.Adresses.Count();
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ContactCount = db.Contacts.Count();
            ViewBag.FeatureCount = db.Features.Count();
            ViewBag.NotificationCount = db.Notifications.Count();
            ViewBag.ReservationCount = db.Reservations.Count();
            ViewBag.ServiceCount = db.Serviceses.Count();
            ViewBag.TestimonialCount = db.Testimonials.Count();
            ViewBag.SpecialsCount = db.Specials.Count();
            ViewBag.productCount = db.Products.Count(); 

            return View();
        }
    }
}
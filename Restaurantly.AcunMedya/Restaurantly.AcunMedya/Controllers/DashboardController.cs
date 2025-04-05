using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.productCount = db.Products.Count();
            ViewBag.categoryCount = db.Categories.Count();
            ViewBag.chefCount = db.Chefs.Count();
            ViewBag.specialcount = db.Specials.Count();
            ViewBag.testimonialCount = db.Testimonials.Count();
            ViewBag.featureCount = db.Features.Count();
            ViewBag.contactCount = db.Contacts.Count();
            ViewBag.reservationCount = db.Reservations.Count();
            ViewBag.notificationCount = db.Notifications.Count();
            ViewBag.eventCount = db.Events.Count();
            ViewBag.adminCount = db.Admins.Count();
            return View();
        }
        public PartialViewResult ReservationPartial()
        {
            var values = db.Reservations.ToList();
            return PartialView(values);
        }
    }
}
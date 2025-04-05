using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Notification
        public ActionResult Index()
        {
            var values = db.Notifications.ToList();
            return View(values);
        }
        public ActionResult Okundu (int id)
        {
            var value = db.Notifications.Find(id);
            value.IsRead = "True";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
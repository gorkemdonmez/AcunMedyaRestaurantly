using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    public class AdminLayoutController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
           ViewBag.notificationIsReadbyfalseCount = db.Notifications.Where(x => x.IsRead == "false").Count();
            var values = db.Notifications.Where(x => x.IsRead == "false").ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var values = db.Notifications.Find(id);
            values.IsRead = "true";
            db.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }
    }
}
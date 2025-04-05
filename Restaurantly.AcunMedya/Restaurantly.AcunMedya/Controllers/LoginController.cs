using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Restaurantly.AcunMedya.Context;
using Restaurantly.AcunMedya.Entities;

namespace Restaurantly.AcunMedya.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = db.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["a"] = values.UserName;
                Session["id"] = values.AdminId;
                Session["surname"] = values.SurName;
                Session["name"] = values.Name;
                Session["img"] = values.ImageUrl;
                


                return RedirectToAction("Index", "Profiles");
            }
            return View();
        }
    }
}
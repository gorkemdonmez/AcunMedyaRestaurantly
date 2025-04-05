using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;
using Restaurantly.AcunMedya.Entities;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Profiles
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = db.Admins.Find(Session["id"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = db.Admins.Find(p.AdminId);
            if (value.Password != p.Password)
            {
                ModelState.AddModelError(string.Empty, "Şifre Yanlış.");
            }
            if (p.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Images\\";
                var fileName = Path.Combine(saveLocation, p.ImageFile.FileName);
                p.ImageFile.SaveAs(fileName);
                value.ImageUrl = "/Images/" + p.ImageFile.FileName;
            }

            value.UserName = p.UserName;
            value.Password = p.Password;
            value.Name = p.Name;
            value.Email = p.Email;
            value.Password = p.Password;
            value.SurName = p.SurName;

            db.SaveChanges();


            return RedirectToAction("Index", "Dashboard");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(Admin p)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = db.Admins.Find(Session["id"]);
            if(p.CurrentPassword != value.Password)
            {
                ModelState.AddModelError(" ", "Şifre Yanlış.");
                return View(p);

            }
          if (p.NewPassword != p.ConfirmPassword)
            {
                ModelState.AddModelError(" ", "Şifreler Uyuşmuyor.");
                return View(p);
            }
            value.Password = p.NewPassword;
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }

    }
}
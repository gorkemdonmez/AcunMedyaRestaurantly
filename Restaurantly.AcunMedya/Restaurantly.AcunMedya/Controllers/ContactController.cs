using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;
using Restaurantly.AcunMedya.Entities;

namespace Restaurantly.AcunMedya.Controllers
{
    public class ContactController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Contact
        public ActionResult Index()
        {
            var values = db.Contacts.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            db.Contacts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ContactEdit(int id)
        {
            var value = db.Contacts.Find(id);
            return View("ContactEdit", value);
        }
        [HttpPost]
        public ActionResult ContactEdit(Contact p)
        {
            var value = db.Contacts.Find(p.ContactId);
            value.Name = p.Name;
            value.Email = p.Email;
            value.Subject = p.Subject;
            value.Message = p.Message;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ContactDelete(int id)
        {
            var value = db.Contacts.Find(id);
            db.Contacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
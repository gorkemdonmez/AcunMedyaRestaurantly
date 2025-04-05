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
    public class TestimonialController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Testimonial
        public ActionResult Index()
        {
            var values = db.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial p)
        {
            db.Testimonials.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TestimonialEdit(int id)
        {
            var value = db.Testimonials.Find(id);
            return View("TestimonialEdit", value);
        }
        [HttpPost]
        public ActionResult TestimonialEdit(Testimonial p)
        {
            var value = db.Testimonials.Find(p.TestimonialId);
            value.Name = p.Name;
            value.Title = p.Title;
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TestimonialDelete(int id)
        {
            var value = db.Testimonials.Find(id);
            db.Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
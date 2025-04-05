using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;

namespace Restaurantly.AcunMedya.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Feature
        public ActionResult Index()
        {
            var value = db.Features.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(Entities.Feature p)
        {
            db.Features.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FeatureEdit(int id)
        {
            var value = db.Features.Find(id);
            return View("FeatureEdit", value);
        }
        [HttpPost]
        public ActionResult FeatureEdit(Entities.Feature p)
        {
            var value = db.Features.Find(p.FeatureId);
            value.Title = p.Title;
            value.SubTitle = p.SubTitle;
            value.VideoUrl = p.VideoUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FeatureDelete(int id)
        {
            var value = db.Features.Find(id);
            db.Features.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
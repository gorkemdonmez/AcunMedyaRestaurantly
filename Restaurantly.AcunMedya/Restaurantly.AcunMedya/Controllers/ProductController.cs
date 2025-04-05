using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurantly.AcunMedya.Context;
using Restaurantly.AcunMedya.Entities;

namespace Restaurantly.AcunMedya.Controllers
{[Authorize]
    public class ProductController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Product

        
        public ActionResult ProductList( string searchText)
        {
            List<Product> values;
            if(searchText !=null)
            {
                values = db.Products.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }

            var value = db.Products.ToList();
            ViewBag.username = Session["a"];
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            List<SelectListItem> value = (from x in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.v1 = value;
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult ProductUpdate(int id)
        {
            var value = db.Products.Find(id);
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.v1 = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product model)
        {
            var values = db.Products.Find(model.CategoryId);
            values.Name = model.Name;
            values.Description = model.Description;
            values.Price = model.Price;
            values.ImageUrl = model.ImageUrl;
            values.CategoryId = model.CategoryId;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = db.Products.Find(id);
            db.Products.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}
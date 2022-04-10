using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        Models.ShoppingEntities db = new Models.ShoppingEntities();
        // GET: Product

        public ActionResult Index()
        {
            var q = new List<Product>();
            q = db.Products.ToList();
            return View(q);
        }

        public ActionResult Product()
        {
            return View();
        }
    }
}
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class CategoryProductController : Controller
    {
        ShoppingEntities db = new ShoppingEntities();
        // GET: CategoryProduct
        public ActionResult Index()
        {
            return View(db.CategoryProducts.ToList());
        }
        public ActionResult AddCategoryProduct()
        {
            CategoryProduct categoryProduct = new CategoryProduct();
            return View(categoryProduct);
        }

        [HttpPost]

        public ActionResult AddCategoryProduct(CategoryProduct Model)
        {
            RandomGenerator_Bill randomGenerator = new RandomGenerator_Bill();
            CategoryProduct cate = new CategoryProduct();
            cate.CateID = randomGenerator.Generate();
            cate.CateName = Model.CateName;
            db.CategoryProducts.Add(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
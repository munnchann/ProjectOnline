using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static List<CategoryProduct> SelectAllArticle1()
        {
            var rtn = new List<CategoryProduct>();
            using (var context = new ShoppingEntities())
            {
                foreach (var item in context.CategoryProducts)
                {
                    rtn.Add(new CategoryProduct
                    {
                        CateID = item.CateID,
                        CateName = item.CateName,
                    });
                }
            }
            return rtn;
        }
        public ActionResult AddProduct()
        {
            Product product = new Product();
            List<CategoryProduct> list = SelectAllArticle1().ToList();
            ViewBag.listCate = new SelectList(list, "CateID", "CateName", "");
            return View(product);
        }
     

        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            RandomGenerator_Product randomGenerator = new RandomGenerator_Product();
            Product pro = new Product();
            List<CategoryProduct> list = SelectAllArticle1().ToList();
            ViewBag.listCate = new SelectList(list, "CateID", "CateName", 1);
            pro.CateProduct = model.CateProduct;
            pro.ProductID = randomGenerator.Generate()+ model.CateProduct;
            pro.ProductName = model.ProductName;   
            pro.Amount = model.Amount;
            pro.Price = model.Price;
            pro.Detail = model.Detail;
            pro.Warranty = model.Warranty;

            string fileName = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
            string extension = Path.GetExtension(model.UploadImage.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.Image = fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            model.UploadImage.SaveAs(fileName);
            pro.Image = model.Image;
            db.Products.Add(pro);
            db.SaveChanges();
            
            return View(pro);
        }
    }
}
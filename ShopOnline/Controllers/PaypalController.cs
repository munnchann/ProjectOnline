using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class PaypalController : Controller
    {
        private const string CartSession = "CartSession";
        Models.ShoppingEntities db = new Models.ShoppingEntities();
        // GET: Paypal
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Success(string email)
        {
                RandomGenerator_Bill generator = new RandomGenerator_Bill();
                var listCart = (List<CartModel>)Session[CartSession];
                Product pro = new Product();
                Bill bill = new Bill();
                bill.BillID = generator.Generate() + pro.ProductID;
                bill.CusID = int.Parse(Session["id"].ToString());
                bill.DateOrder = DateTime.Now;
                if(ViewBag.Transport == "PayPal")
                {
                    bill.TypeBill = "PayPal";
                }
                else
                {
                    bill.TypeBill = "COD";
                }
                if(ViewBag.Transport == "PalPal")
                {
                    bill.Status = "Paid";
                }
                else
                {
                    bill.Status = "Unpaid";
                }
                bill.TransportPrice = ViewBag.Address;
                string IDOrder = bill.BillID;
                
                List<DetailBill> lsdetail = new List<DetailBill>();
                foreach(var item in listCart)
                {
                    DetailBill dt = new DetailBill();
                    dt.BillID = IDOrder;
                    dt.Amount = item.Quantity;
                    dt.Price = item.product.Price;
                    dt.ProductID = item.product.ProductID;
                    dt.TotalPrice = ((item.product.Price * item.Quantity) + Convert.ToDecimal( ViewBag.Address));

                    lsdetail.Add(dt);
               
                }
                db.DetailBills.AddRange(lsdetail);
                db.SaveChanges();
                Session[CartSession] = null;
                Session["count"] = null;
            
            return View();
        }

        [HttpGet]
        public ActionResult Success1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Success1(string email)
        {
            RandomGenerator_Bill generator = new RandomGenerator_Bill();
            var listCart = (List<CartModel>)Session[CartSession];
            Product pro = new Product();
            Bill bill = new Bill();
            bill.BillID = generator.Generate() + pro.ProductID;
            bill.CusID = int.Parse(Session["id"].ToString());
            bill.DateOrder = DateTime.Now;
            if (ViewBag.Transport == "PayPal")
            {
                bill.TypeBill = "PayPal";
            }
            else
            {
                bill.TypeBill = "COD";
            }
            if (ViewBag.Transport == "PalPal")
            {
                bill.Status = "Paid";
            }
            else
            {
                bill.Status = "Unpaid";
            }
            bill.TransportPrice = ViewBag.Address;
            string IDOrder = bill.BillID;

            List<DetailBill> lsdetail = new List<DetailBill>();
            foreach (var item in listCart)
            {
                DetailBill dt = new DetailBill();
                dt.BillID = IDOrder;
                dt.Amount = item.Quantity;
                dt.Price = item.product.Price;
                dt.ProductID = item.product.ProductID;
                dt.TotalPrice = ((item.product.Price * item.Quantity) + Convert.ToDecimal(ViewBag.Address));

                lsdetail.Add(dt);

            }
            db.DetailBills.AddRange(lsdetail);
            db.SaveChanges();
            Session[CartSession] = null;
            Session["count"] = null;

            return View();
        }

    }
}
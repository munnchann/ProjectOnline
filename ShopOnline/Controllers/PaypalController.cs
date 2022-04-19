using ShopOnline.Models;
using ShopOnline.Pay;
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
        public ActionResult GetDataPaypal()
        {
            var getData = new GetDataPaypal();
            var order = getData.InformationOrder(getData.GetPayPalResponse(Request.QueryString["tx"]));
            ViewBag.tx = Request.QueryString["tx"];
            RandomGenerator_Bill generator = new RandomGenerator_Bill();
            //get product cart first 
            var listCart = (List<CartModel>)Session[CartSession];
            var q = listCart.FirstOrDefault();
            Bill bill = new Bill();
            bill.BillID = generator.Generate();
            bill.CusID = int.Parse(Session["id"].ToString());
            bill.DateOrder = DateTime.Now;
            bill.TypeBill = "PayPal";
            bill.Status = "Paid";
            
            //bill.ShippingName = ViewBag.NVC;
            if (Session["address"].ToString() == "TPHCM")
            {
                bill.TransportPrice = 1;
            }
            if (Session["address"].ToString() == "Thành phố Hồ Chí Minh")
            {
                bill.TransportPrice = 1;
            }
            if (Session["address"].ToString() == "Hà Nội")
            {
                bill.TransportPrice = 2;
            }
            if (Session["address"].ToString() == "HN")
            {
                bill.TransportPrice = 2;
            }
            db.Bills.Add(bill);
            db.SaveChanges();
            string IDOrder = bill.BillID;

            List<DetailBill> lsdetail = new List<DetailBill>();
            List<Models.Order> lsord = new List<Order>();
            foreach (var item in listCart)
            {
                DetailBill dt = new DetailBill();
                dt.BillID = IDOrder;
                dt.Amount = item.Quantity;
                dt.Price = item.product.Price;
                dt.ProductID = item.product.ProductID;
                dt.TotalPrice = (item.product.Price * item.Quantity);
                lsdetail.Add(dt);
            }
            db.DetailBills.AddRange(lsdetail);
            db.SaveChanges();

            string proid = q.product.ProductID;
            Order or = new Order();
            or.OrderID = bill.BillID + proid;
            db.Orders.AddRange(lsord);
            db.SaveChanges();
            Session[CartSession] = null;
            Session["count"] = null;

            return View();
        }
        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Success(Product product)
        {

            RandomGenerator_Bill generator = new RandomGenerator_Bill();
            var listCart = (List<CartModel>)Session[CartSession];
            Bill bill = new Bill();
            bill.BillID = generator.Generate();
            bill.CusID = int.Parse(Session["id"].ToString());
            bill.DateOrder = DateTime.Now;          
            bill.TypeBill = "COD";
            bill.Status = "Unpaid";
            if (Session["address"].ToString() == "TPHCM")
            {
                bill.TransportPrice = 1;
            }
            if (Session["address"].ToString() == "Thành phố Hồ Chí Minh")
            {
                bill.TransportPrice = 1;
            }
            if (Session["address"].ToString() == "Hà Nội")
            {
                bill.TransportPrice = 2;
            }
            if (Session["address"].ToString() == "HN")
            {
                bill.TransportPrice = 2;
            }
            db.Bills.Add(bill);
            db.SaveChanges();
            string IDOrder = bill.BillID;

            List<DetailBill> lsdetail = new List<DetailBill>();
            foreach (var item in listCart)
            {
                DetailBill dt = new DetailBill();
                dt.BillID = IDOrder;
                dt.Amount = item.Quantity;
                dt.Price = item.product.Price;
                dt.ProductID = item.product.ProductID;
                dt.TotalPrice = (item.product.Price * item.Quantity);
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
        public ActionResult Success1(Product product)
        {
            RandomGenerator_Bill generator = new RandomGenerator_Bill();
            var listCart = (List<CartModel>)Session[CartSession];        
            Bill bill = new Bill();
            bill.BillID = generator.Generate();
            bill.CusID = int.Parse(Session["id"].ToString());
            bill.DateOrder = DateTime.Now;
            bill.TypeBill = "COD";
            bill.Status = "Unpaid";
            if (Session["address"].ToString() == "TPHCM")
            {
                bill.TransportPrice = 1;
            }
            if (Session["address"].ToString() == "Thành phố Hồ Chí Minh")
            {
                bill.TransportPrice = 1;
            }
            if (Session["address"].ToString() == "Hà Nội")
            {
                bill.TransportPrice = 2;
            }
            if (Session["address"].ToString() == "HN")
            {
                bill.TransportPrice = 2;
            }
            db.Bills.Add(bill);
            db.SaveChanges();
            string IDOrder = bill.BillID;

            List<DetailBill> lsdetail = new List<DetailBill>();
            List<Models.Order> lsord = new List<Order>();
            foreach (var item in listCart)
            {
                DetailBill dt = new DetailBill();
                dt.BillID = IDOrder;
                dt.Amount = item.Quantity;
                dt.Price = item.product.Price;
                dt.ProductID = item.product.ProductID;
                dt.TotalPrice = (item.product.Price * item.Quantity);
                lsdetail.Add(dt);      
            }
            db.DetailBills.AddRange(lsdetail);
            db.SaveChanges();
            foreach(var item in listCart)
            {
                Models.Order ord = new Models.Order();
                ord.OrderID =  bill.BillID + item.product.ProductID;
                ord.BillID = IDOrder;
                ord.CusID = int.Parse(Session["id"].ToString());
                ord.DateOrder = bill.DateOrder;
                ord.Stt = "wait for confirmation";
                lsord.Add(ord);
                
            }
            //List<Models.Order> uniqueLst = lsord.Distinct().ToList();
            db.Orders.AddRange(lsord);
            db.SaveChanges();
            Session[CartSession] = null;
            Session["count"] = null;

            return View();
        }

    }
}
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagedList;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopOnline.Controllers
{
    public class CartController : Controller
    {
        //private readonly string _clientId;
        //private readonly string _secretKey;
        Models.ShoppingEntities db = new Models.ShoppingEntities();
        private const string CartSession = "CartSession";
        // GET: Cart
        //public CartController(IConfiguration config)
        //{
        //    _clientId = config["PaypalSettings:ClientId"];
        //    _secretKey = config["PaypalSettings:SecretKey"];
        //}
        [HttpGet]
        public ActionResult Index()
        {
            var session = Session[CartSession];
            List<CartModel> currentCart = new List<CartModel>();
            if (session != null)
            {
                currentCart = (List<CartModel>)session;
            }
            return View(currentCart);
        }
        public ActionResult GetListItems()
        {
            var session = Session[CartSession];
            var currentCart = new List<CartModel>();
            if (session != null)
            {
                currentCart = (List<CartModel>)session;
            }
            return View(currentCart);
        }
        public ActionResult AddToCart(string productId)
        {
            var session = Session[CartSession];
            if (session == null)
            {

                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel
                {
                    product = db.Products.Find(productId),
                    Quantity = 1
                });
                Session[CartSession] = cart;
                //Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)session;
                int index = isExist(productId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartModel { product = db.Products.Find(productId), Quantity = 1 });
                    //Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index", "Product");

        }
        private int isExist(string productId)
        {
            List<CartModel> cart = (List<CartModel>)Session[CartSession];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.ProductID.Equals(productId))
                    return i;
            return -1;
        }

        public ActionResult Update(string id, int quantity)
        {
            var session = Session[CartSession];
            List<CartModel> currentCart = new List<CartModel>();
            if (session != null)
                currentCart = (List<CartModel>)session;
            foreach (var item in currentCart)
            {
                if (item.product.ProductID == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        //Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            Session[CartSession] = currentCart;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        public ActionResult DeleteAll()
        {
            Session[CartSession] = new List<CartModel>();
            return Json(new
            {
                status = true
            });

        }

        //public ActionResult DeleteItem(string id)
        //{
        //    var cartSession = (List<CartModel>)Session[CartSession];
        //    if (cartSession != null)
        //    {
        //        cartSession.RemoveAll(x => x.product.ProductID == id);
        //        Session[CartSession] = cartSession;
        //        Session["count"] = Convert.ToInt32(Session["count"]) - 1;
        //        return RedirectToAction("Index", "Cart");
        //    }
        //    return RedirectToAction("Index", "Cart");
        //}
        public ActionResult Checkout()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("LoginUser", "Login");
            }
            if (Session["address"].ToString() == "TPHCM")
            {
                ViewBag.Address = 1;
            }
            if (Session["address"].ToString() == "Thành phố Hồ Chí Minh")
            {
                ViewBag.Address = 1;
            }
            if (Session["address"].ToString() == "Hà Nội")
            {
                ViewBag.Address = 2;
            }
            if (Session["address"].ToString() == "HN")
            {
                ViewBag.Address = 2;
            }
            var session = Session[CartSession];
            List<CartModel> currentCart = new List<CartModel>();
            if (session != null)
            {
                currentCart = (List<CartModel>)session;
            }
            return View(currentCart);

        }
        public ActionResult Order_Tracking(int? page)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("LoginUser", "Login");
            }

            var currentCart = new List<Order>();
            var session = Convert.ToInt32(Session["id"]);
            List<Order> list = (from a in db.Orders where a.Stt == "wait for confirmation" && a.CusID == session select a).ToList();
            currentCart = list.ToList();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            list = list.OrderByDescending(n => n.OrderID).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Order_Tracking1(int? page)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("LoginUser", "Login");
            }

            var currentCart = new List<Order>();
            var session = Convert.ToInt32(Session["id"]);
            List<Order> list = (from a in db.Orders where a.Stt == "confirmed" && a.CusID == session select a).ToList();
            currentCart = list.ToList();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            list = list.OrderByDescending(n => n.OrderID).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Order_Tracking2(int? page)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("LoginUser", "Login");
            }

            var currentCart = new List<Order>();
            var session = Convert.ToInt32(Session["id"]);
            List<Order> list = (from a in db.Orders where a.Stt == "being shipped" && a.CusID == session select a).ToList();
            currentCart = list.ToList();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            list = list.OrderByDescending(n => n.OrderID).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Order_Tracking3(int? page)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("LoginUser", "Login");
            }

            var currentCart = new List<Order>();
            var session = Convert.ToInt32(Session["id"]);
            List<Order> list = (from a in db.Orders where a.Stt == "Accomplished" && a.CusID == session select a).ToList();
            currentCart = list.ToList();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            list = list.OrderByDescending(n => n.OrderID).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        
        public PartialViewResult CartBag()
        {
            int total = 0;
            var session = Session[CartSession];
            var currentCart = new List<CartModel>();
            if (session != null)
                currentCart = (List<CartModel>)session;
            var t1 = currentCart.Sum(s => s.Quantity);
            total = currentCart.Count(x => x.Quantity <= t1);            
            ViewBag.QuantityCart = total;
            return PartialView("CartBag");
        }
    }
}
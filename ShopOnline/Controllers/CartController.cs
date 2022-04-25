using Newtonsoft.Json;
using ShopOnline.Constants;
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
        Models.ShoppingEntities db = new Models.ShoppingEntities();
        private const string CartSession = "CartSession";
        // GET: Cart    
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
        [HttpGet]
        public ActionResult GetListItems()
        {
            var session = Session[CartSession];
            List<CartModel> currentCart = new List<CartModel>();
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
                List<CartModel> currentCart = new List<CartModel>();
                currentCart.Add(new CartModel
                {
                    product = db.Products.Find(productId),
                    Quantity = 1
                });
                Session[CartSession] = currentCart;
                Session["count"] = 1;
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
                    cart.Add(new CartModel
                    {
                        product = db.Products.Find(productId),
                        Quantity = 1
                    });
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
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
                        Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                        break;
                        }
                        item.Quantity = quantity;
                    }
                }

            Session[CartSession] = currentCart;
            //return RedirectToAction("Index","Cart");
            return Json(new
            {
                status = true
            });
        }
        
        public ActionResult DeleteAll()
        {
            Session[CartSession] = new List<CartModel>();
            return Json(new
            {
                status = true
            });
            
        }
        
        public ActionResult DeleteItem(string id)
        {
            var cartSession = (List<CartModel>)Session[CartSession];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.product.ProductID == id);
                Session[CartSession] = cartSession;
                Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Checkout()
        {
            return View();
        }
    }
}
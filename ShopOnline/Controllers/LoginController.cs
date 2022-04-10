using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class LoginController : Controller
    {
        Models.ShoppingEntities db = new Models.ShoppingEntities();
        // GET: Login
        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.Customers.Where(x => x.UserName.Equals(username) && x.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["name"] = data.FirstOrDefault().CusName;
                    Session["id"] = data.FirstOrDefault().CusID;
                    Session["phone"] = data.FirstOrDefault().Address;
                    Session["address"] = data.FirstOrDefault().Address;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password failed. Try Again!");
                    return RedirectToAction("LoginUser", "Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("LoginUser");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
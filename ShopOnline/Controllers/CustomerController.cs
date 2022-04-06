using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{

    public class CustomerController : Controller
    {
        ShoppingEntities db = new ShoppingEntities();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCustomer()
        {
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]

        public ActionResult AddCustomer(Customer model)
        {
            Customer cus = new Customer();
            cus.CusID = model.CusID;
            cus.CusName = model.CusName;
            cus.Address = model.Address;
            cus.UserName = model.UserName;
            cus.Password = model.Password;
            cus.Phone = model.Phone;
            cus.Image = model.Image;
            db.Customers.Add(cus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
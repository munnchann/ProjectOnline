using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult ViewCus()
        {
            return View();
        }

        public ActionResult DeleteCus()
        {
            return View();
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult ViewOrd()
        {
            return View();
        }

        public ActionResult Ord()
        {
            return View();
        }

        
    }

}
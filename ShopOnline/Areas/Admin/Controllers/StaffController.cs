using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        public ActionResult ViewStaff()
        {
            return View();
        }

        public ActionResult EditStaff()
        {
            return View();
        }

        public ActionResult AdStaff()
        {
            return View();
        }

    }
}
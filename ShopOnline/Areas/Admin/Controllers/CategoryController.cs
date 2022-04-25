using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult ViewCategory()
        {
            return View();
        }

        public ActionResult EditCate()
        {
            return View();
        }

        public ActionResult DeleteCate()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class IndexAdController : Controller
    {
        // GET: Admin/IndexAd
        public ActionResult Index()
        {
            return View();
        }
    }
}
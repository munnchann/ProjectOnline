using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult AddPosition()
        {
            Position position = new Position();
            return View(position);
        }
        [HttpPost]
        public ActionResult AddPosition(Position model)
        {
            Position position = new Position();
            position.PositionID = model.PositionID;
            position.PositionName = model.PositionName;
            db.Positions.Add(position);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            return View(db.Positions.ToList());
        }
    }
}
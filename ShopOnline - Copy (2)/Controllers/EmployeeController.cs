using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class EmployeeController : Controller
    {
        ShoppingEntities db = new ShoppingEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addemptomer()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]

        public ActionResult AddEmployee(Employee model)
        {
            Employee emp = new Employee();
            emp.EmployeeID = model.EmployeeID;
            emp.EmployeeName = model.EmployeeName;
            emp.UserName = model.UserName;
            emp.Password = model.Password;
            emp.Phone = model.Phone;    
            emp.Salary = model.Salary;
            emp.Image = model.Image;
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
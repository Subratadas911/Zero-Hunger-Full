using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class employeeloginController : Controller
    {
        ZhungerEntities db = new ZhungerEntities();
        // GET: employeelogin

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(employee emp)
        {
            var chk = db.employees.Where(x => x.employeename.Equals(emp.employeename) && x.password.Equals(emp.password)).FirstOrDefault();
            if (chk != null)
            {
                Session["Id"] = emp.id.ToString();
                Session["username"] = emp.employeename.ToString();
                return RedirectToAction("Index", "EmpShow");
            }
            else
            {
                ViewBag.notification = "Wrong username or password!";
            }
            return View();
        }
    }
}
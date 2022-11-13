using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{

    public class AdminController : Controller
    {
        ZhungerEntities db = new ZhungerEntities();
        // GET: Admin


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin ad)
        {
            var chk = db.Admins.Where(x => x.name.Equals(ad.name) && x.password.Equals(ad.password)).FirstOrDefault();
            if (chk != null)
            {
                Session["Id"] = ad.id.ToString();
                Session["username"] = ad.name.ToString();
                return RedirectToAction("AdminPage");
            }
            else
            {
                ViewBag.notification = "Wrong username or password!";
            }
            return View();


        }
        public ActionResult AdminPage()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class RestaurentController : Controller
    {
        ZhungerEntities db = new ZhungerEntities();
        // GET: Restaurent
        public ActionResult Index()
        {
            
            return View(db.Restaurents.ToList());
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Restaurent resto )
        {
            if (db.Restaurents.Any(x => x.restaurentname == resto.restaurentname))
            {
                ViewBag.notification = "This account using the restaurent name already exist";


            }
            else
            {

                db.Restaurents.Add(resto);
                db.SaveChanges();

                Session["Id"] = resto.id.ToString();
                Session["username"] = resto.restaurentname.ToString();

                return RedirectToAction("Index", "Home");

            }
            return View();
            
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Restaurent");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Restaurent restau)
        {
            var chk = db.Restaurents.Where(x => x.restaurentname.Equals(restau.restaurentname) && x.password.Equals(restau.password)).FirstOrDefault();
           if(chk != null)
            {
                Session["Id"] = restau.id.ToString();
                Session["username"] = restau.restaurentname.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.notification = "Wrong username or password!";
            }
            return View();
        }


    }
}
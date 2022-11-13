using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class ngoController : Controller
    {

        ZhungerEntities db = new ZhungerEntities();

        // GET: ngo
        public ActionResult Index()
        {
            var result = (from r in db.ngoes
                          join c in db.Frestaurents on r.resid equals c.resname

                          select new NgoAvail
                          {
                            id = r.id,
                            resid = r.resid,
                            employeeid = r.employeeid,
                            sdate = r.sdate,
                            edate = r.edate,
                            available = c.available


                          }).ToList();




            return View(result);
        }

        [HttpGet]
        public ActionResult Getres()
        {
           var res = db.Frestaurents.ToList();
            return Json(res, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult Getid(int id)
        {
            var emp = (from s in db.employees where s.id == id select s.employeename).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult Getavail(String resname)
        {
           var foodavail = (from s in db.Frestaurents where s.resname == resname select s.available).FirstOrDefault();
            return Json(foodavail, JsonRequestBehavior.AllowGet);


        }









        [HttpPost]
        public ActionResult Save(ngo NGO)
        {
            
           if(ModelState.IsValid)
            {
                db.ngoes.Add(NGO);
                var Res = db.Frestaurents.SingleOrDefault(e => e.resname == NGO.resid);
                if (Res == null)
                    return HttpNotFound("Restaurant is not available");
                Res.available = "no";
                db.Entry(Res).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

               
            }
           return View(NGO);

        }




    }
}
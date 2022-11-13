using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class EmpShowController : Controller
    {
        ZhungerEntities db = new ZhungerEntities();
        // GET: Fdistribution
        public ActionResult Index()
        {
            var show = db.Fdistributions.ToList();
            return View(show);
        }


        public ActionResult Save(Fdistribution fd)
        {
            if (ModelState.IsValid)
            {
                db.Fdistributions.Add(fd);
                var res = db.Frestaurents.SingleOrDefault(e => e.resname == fd.resname);
                if (res == null)
                    return HttpNotFound("Restaurent not found");
                res.available = "yes";
                db.Entry(res).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(fd);
        }



        [HttpPost]
        public ActionResult Getid(String resname)
        {
            var rest = (from s in db.ngoes
                        where s.resid == resname
                        select new
                        {
                            StartDate = s.sdate,
                            EndDate = s.edate,
                            Employeeid = s.employeeid,
                            Resname = s.resid,
                            Exdate = SqlFunctions.DateDiff("day", s.edate, DateTime.Now)
                        }).ToArray();


            return Json(rest, JsonRequestBehavior.AllowGet);

        }

    }
}
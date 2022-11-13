using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class FrestaurentsController : Controller
    {
        private ZhungerEntities db = new ZhungerEntities();

        // GET: Frestaurents
        public ActionResult Index()
        {
            return View(db.Frestaurents.ToList());
        }
       

        // GET: Frestaurents/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frestaurent frestaurent = db.Frestaurents.Find(id);
            if (frestaurent == null)
            {
                return HttpNotFound();
            }
            return View(frestaurent);
        }

        // GET: Frestaurents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Frestaurents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,resname,address,fooditem,available,date")] Frestaurent frestaurent)
        {
            if (ModelState.IsValid)
            {
                db.Frestaurents.Add(frestaurent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frestaurent);
        }

        // GET: Frestaurents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frestaurent frestaurent = db.Frestaurents.Find(id);
            if (frestaurent == null)
            {
                return HttpNotFound();
            }
            return View(frestaurent);
        }

        // POST: Frestaurents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,resname,address,fooditem,available,date")] Frestaurent frestaurent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frestaurent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frestaurent);
        }

        // GET: Frestaurents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frestaurent frestaurent = db.Frestaurents.Find(id);
            if (frestaurent == null)
            {
                return HttpNotFound();
            }
            return View(frestaurent);
        }

        // POST: Frestaurents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frestaurent frestaurent = db.Frestaurents.Find(id);
            db.Frestaurents.Remove(frestaurent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

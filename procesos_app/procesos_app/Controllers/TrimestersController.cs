using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using procesos_app.Models;

namespace procesos_app.Controllers
{
    public class TrimestersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trimesters
        public ActionResult Index()
        {
            return View(db.Trimesters.ToList());
        }

        // GET: Trimesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimester trimester = db.Trimesters.Find(id);
            if (trimester == null)
            {
                return HttpNotFound();
            }
            return View(trimester);
        }

        // GET: Trimesters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trimesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Inicio,Fin")] Trimester trimester)
        {
            if (ModelState.IsValid)
            {
                db.Trimesters.Add(trimester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trimester);
        }

        // GET: Trimesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimester trimester = db.Trimesters.Find(id);
            if (trimester == null)
            {
                return HttpNotFound();
            }
            return View(trimester);
        }

        // POST: Trimesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Inicio,Fin")] Trimester trimester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trimester);
        }

        // GET: Trimesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimester trimester = db.Trimesters.Find(id);
            if (trimester == null)
            {
                return HttpNotFound();
            }
            return View(trimester);
        }

        // POST: Trimesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trimester trimester = db.Trimesters.Find(id);
            db.Trimesters.Remove(trimester);
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

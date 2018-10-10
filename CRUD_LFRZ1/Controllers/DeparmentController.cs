using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_LFRZ1.Models;

namespace CRUD_LFRZ1.Controllers
{
    public class DeparmentController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: Deparment
        public ActionResult Index()
        {
            return View(db.Deparments.ToList());
        }

        // GET: Deparment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparment deparment = db.Deparments.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // GET: Deparment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deparment/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.Deparments.Add(deparment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deparment);
        }

        // GET: Deparment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparment deparment = db.Deparments.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: Deparment/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deparment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deparment);
        }

        // GET: Deparment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparment deparment = db.Deparments.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: Deparment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deparment deparment = db.Deparments.Find(id);
            db.Deparments.Remove(deparment);
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

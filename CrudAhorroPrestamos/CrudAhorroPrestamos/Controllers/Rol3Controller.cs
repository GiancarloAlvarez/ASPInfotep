using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudAhorroPrestamos.Models;

namespace CrudAhorroPrestamos.Controllers
{
    public class Rol3Controller : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: Rol3
        public ActionResult Index()
        {
            return View(db.Rol3.ToList());
        }

        // GET: Rol3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol3 rol3 = db.Rol3.Find(id);
            if (rol3 == null)
            {
                return HttpNotFound();
            }
            return View(rol3);
        }

        // GET: Rol3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol3/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rol,Clasificacion,id_cliente")] Rol3 rol3)
        {
            if (ModelState.IsValid)
            {
                db.Rol3.Add(rol3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rol3);
        }

        // GET: Rol3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol3 rol3 = db.Rol3.Find(id);
            if (rol3 == null)
            {
                return HttpNotFound();
            }
            return View(rol3);
        }

        // POST: Rol3/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rol,Clasificacion,id_cliente")] Rol3 rol3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol3);
        }

        // GET: Rol3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol3 rol3 = db.Rol3.Find(id);
            if (rol3 == null)
            {
                return HttpNotFound();
            }
            return View(rol3);
        }

        // POST: Rol3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol3 rol3 = db.Rol3.Find(id);
            db.Rol3.Remove(rol3);
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

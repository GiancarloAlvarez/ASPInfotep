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
    public class GarantiasController : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: Garantias
        public ActionResult Index()
        {
            var garantia = db.Garantia.Include(g => g.prestamos);
            return View(garantia.ToList());
        }

        // GET: Garantias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantia.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // GET: Garantias/Create
        public ActionResult Create()
        {
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo");
            return View();
        }

        // POST: Garantias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_garantia,CodigoGarantia,TipoGarantia,precio,id_prestamo")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Garantia.Add(garantia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", garantia.id_prestamo);
            return View(garantia);
        }

        // GET: Garantias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantia.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", garantia.id_prestamo);
            return View(garantia);
        }

        // POST: Garantias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_garantia,CodigoGarantia,TipoGarantia,precio,id_prestamo")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garantia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", garantia.id_prestamo);
            return View(garantia);
        }

        // GET: Garantias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantia.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // POST: Garantias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garantia garantia = db.Garantia.Find(id);
            db.Garantia.Remove(garantia);
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

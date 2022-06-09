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
    public class CuotasController : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: Cuotas
        public ActionResult Index()
        {
            var cuota = db.Cuota.Include(c => c.prestamos);
            return View(cuota.ToList());
        }

        // GET: Cuotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota cuota = db.Cuota.Find(id);
            if (cuota == null)
            {
                return HttpNotFound();
            }
            return View(cuota);
        }

        // GET: Cuotas/Create
        public ActionResult Create()
        {
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo");
            return View();
        }

        // POST: Cuotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuota,Fecha,MontoCuota,FechaEfectivaCuota,TipoPago,id_prestamo")] Cuota cuota)
        {
            if (ModelState.IsValid)
            {
                db.Cuota.Add(cuota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", cuota.id_prestamo);
            return View(cuota);
        }

        // GET: Cuotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota cuota = db.Cuota.Find(id);
            if (cuota == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", cuota.id_prestamo);
            return View(cuota);
        }

        // POST: Cuotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuota,Fecha,MontoCuota,FechaEfectivaCuota,TipoPago,id_prestamo")] Cuota cuota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", cuota.id_prestamo);
            return View(cuota);
        }

        // GET: Cuotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota cuota = db.Cuota.Find(id);
            if (cuota == null)
            {
                return HttpNotFound();
            }
            return View(cuota);
        }

        // POST: Cuotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuota cuota = db.Cuota.Find(id);
            db.Cuota.Remove(cuota);
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

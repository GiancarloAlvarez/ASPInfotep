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
    public class prestamosController : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: prestamos
        public ActionResult Index()
        {
            var prestamos = db.prestamos.Include(p => p.Cliente);
            return View(prestamos.ToList());
        }

        // GET: prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamos prestamos = db.prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // GET: prestamos/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre");
            return View();
        }

        // POST: prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prestamo,CodigoPrestamo,FechaSolicitud,FechaAprobacion,FechaInicio,FechaTermico,RetornoCapital,MontoPrestamo,TasaInteres,id_cliente")] prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                db.prestamos.Add(prestamos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", prestamos.id_cliente);
            return View(prestamos);
        }

        // GET: prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamos prestamos = db.prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", prestamos.id_cliente);
            return View(prestamos);
        }

        // POST: prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prestamo,CodigoPrestamo,FechaSolicitud,FechaAprobacion,FechaInicio,FechaTermico,RetornoCapital,MontoPrestamo,TasaInteres,id_cliente")] prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", prestamos.id_cliente);
            return View(prestamos);
        }

        // GET: prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamos prestamos = db.prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // POST: prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prestamos prestamos = db.prestamos.Find(id);
            db.prestamos.Remove(prestamos);
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

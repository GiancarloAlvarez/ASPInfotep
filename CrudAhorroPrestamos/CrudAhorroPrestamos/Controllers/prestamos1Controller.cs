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
    public class prestamos1Controller : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: prestamos1
        public ActionResult Index()
        {
            var prestamos1 = db.prestamos1.Include(p => p.Cliente);
            return View(prestamos1.ToList());
        }

        // GET: prestamos1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamos1 prestamos1 = db.prestamos1.Find(id);
            if (prestamos1 == null)
            {
                return HttpNotFound();
            }
            return View(prestamos1);
        }

        // GET: prestamos1/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre");
            return View();
        }

        // POST: prestamos1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prestamo,CodigoPrestamo,FechaSolicitud,FechaAprobacion,MontoPrestamo,TasaInteres,Plazo,id_cliente")] prestamos1 prestamos1)
        {
            if (ModelState.IsValid)
            {
                db.prestamos1.Add(prestamos1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", prestamos1.id_cliente);
            return View(prestamos1);
        }

        // GET: prestamos1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamos1 prestamos1 = db.prestamos1.Find(id);
            if (prestamos1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", prestamos1.id_cliente);
            return View(prestamos1);
        }

        // POST: prestamos1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prestamo,CodigoPrestamo,FechaSolicitud,FechaAprobacion,MontoPrestamo,TasaInteres,Plazo,id_cliente")] prestamos1 prestamos1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamos1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", prestamos1.id_cliente);
            return View(prestamos1);
        }

        // GET: prestamos1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamos1 prestamos1 = db.prestamos1.Find(id);
            if (prestamos1 == null)
            {
                return HttpNotFound();
            }
            return View(prestamos1);
        }

        // POST: prestamos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prestamos1 prestamos1 = db.prestamos1.Find(id);
            db.prestamos1.Remove(prestamos1);
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

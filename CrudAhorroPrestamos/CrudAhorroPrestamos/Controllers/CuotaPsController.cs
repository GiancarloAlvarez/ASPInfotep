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
    public class CuotaPsController : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: CuotaPs
        public ActionResult Index()
        {
            var cuotaP = db.CuotaP.Include(c => c.Cliente).Include(c => c.prestamos);
            return View(cuotaP.ToList());
        }

        // GET: CuotaPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuotaP cuotaP = db.CuotaP.Find(id);
            if (cuotaP == null)
            {
                return HttpNotFound();
            }
            return View(cuotaP);
        }

        // GET: CuotaPs/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre");
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo");
            return View();
        }

        // POST: CuotaPs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuota,Fecha,MontoCuota,FechaEfectivaCuota,TipoPago,Plazo,id_cliente,id_prestamo")] CuotaP cuotaP)
        {
            if (ModelState.IsValid)
            {
                db.CuotaP.Add(cuotaP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", cuotaP.id_cliente);
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", cuotaP.id_prestamo);
            return View(cuotaP);
        }

        // GET: CuotaPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuotaP cuotaP = db.CuotaP.Find(id);
            if (cuotaP == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", cuotaP.id_cliente);
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", cuotaP.id_prestamo);
            return View(cuotaP);
        }

        // POST: CuotaPs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuota,Fecha,MontoCuota,FechaEfectivaCuota,TipoPago,Plazo,id_cliente,id_prestamo")] CuotaP cuotaP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuotaP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", cuotaP.id_cliente);
            ViewBag.id_prestamo = new SelectList(db.prestamos, "id_prestamo", "CodigoPrestamo", cuotaP.id_prestamo);
            return View(cuotaP);
        }

        // GET: CuotaPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuotaP cuotaP = db.CuotaP.Find(id);
            if (cuotaP == null)
            {
                return HttpNotFound();
            }
            return View(cuotaP);
        }

        // POST: CuotaPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuotaP cuotaP = db.CuotaP.Find(id);
            db.CuotaP.Remove(cuotaP);
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

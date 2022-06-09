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
    public class inversionsController : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: inversions
        public ActionResult Index()
        {
            var inversion = db.inversion.Include(i => i.Cliente);
            return View(inversion.ToList());
        }

        // GET: inversions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversion inversion = db.inversion.Find(id);
            if (inversion == null)
            {
                return HttpNotFound();
            }
            return View(inversion);
        }

        // GET: inversions/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre");
            return View();
        }

        // POST: inversions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_inversion,CodigoInversion,MontoInversion,TasaInteres,FechaInversion,FechaRembolso,id_cliente")] inversion inversion)
        {
            if (ModelState.IsValid)
            {
                db.inversion.Add(inversion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", inversion.id_cliente);
            return View(inversion);
        }

        // GET: inversions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversion inversion = db.inversion.Find(id);
            if (inversion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", inversion.id_cliente);
            return View(inversion);
        }

        // POST: inversions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_inversion,CodigoInversion,MontoInversion,TasaInteres,FechaInversion,FechaRembolso,id_cliente")] inversion inversion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inversion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", inversion.id_cliente);
            return View(inversion);
        }

        // GET: inversions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversion inversion = db.inversion.Find(id);
            if (inversion == null)
            {
                return HttpNotFound();
            }
            return View(inversion);
        }

        // POST: inversions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inversion inversion = db.inversion.Find(id);
            db.inversion.Remove(inversion);
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

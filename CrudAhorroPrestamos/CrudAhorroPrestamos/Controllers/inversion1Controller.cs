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
    public class inversion1Controller : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: inversion1
        public ActionResult Index()
        {
            var inversion1 = db.inversion1.Include(i => i.Cliente);
            return View(inversion1.ToList());
        }

        // GET: inversion1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversion1 inversion1 = db.inversion1.Find(id);
            if (inversion1 == null)
            {
                return HttpNotFound();
            }
            return View(inversion1);
        }

        // GET: inversion1/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre");
            return View();
        }

        // POST: inversion1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_inversion,CodigoInversion,MontoInversion,TasaInteres,FechaInversion,FechaRembolso,Plazo,id_cliente")] inversion1 inversion1)
        {
            if (ModelState.IsValid)
            {
                db.inversion1.Add(inversion1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", inversion1.id_cliente);
            return View(inversion1);
        }

        // GET: inversion1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversion1 inversion1 = db.inversion1.Find(id);
            if (inversion1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", inversion1.id_cliente);
            return View(inversion1);
        }

        // POST: inversion1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_inversion,CodigoInversion,MontoInversion,TasaInteres,FechaInversion,FechaRembolso,Plazo,id_cliente")] inversion1 inversion1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inversion1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", inversion1.id_cliente);
            return View(inversion1);
        }

        // GET: inversion1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversion1 inversion1 = db.inversion1.Find(id);
            if (inversion1 == null)
            {
                return HttpNotFound();
            }
            return View(inversion1);
        }

        // POST: inversion1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inversion1 inversion1 = db.inversion1.Find(id);
            db.inversion1.Remove(inversion1);
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

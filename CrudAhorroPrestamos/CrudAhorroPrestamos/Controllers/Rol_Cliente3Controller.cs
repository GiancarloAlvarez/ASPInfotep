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
    public class Rol_Cliente3Controller : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: Rol_Cliente3
        public ActionResult Index()
        {
            var rol_Cliente3 = db.Rol_Cliente3.Include(r => r.Cliente).Include(r => r.Rol3);
            return View(rol_Cliente3.ToList());
        }

        // GET: Rol_Cliente3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Cliente3 rol_Cliente3 = db.Rol_Cliente3.Find(id);
            if (rol_Cliente3 == null)
            {
                return HttpNotFound();
            }
            return View(rol_Cliente3);
        }

        // GET: Rol_Cliente3/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre");
            ViewBag.id_rol = new SelectList(db.Rol3, "id_rol", "Clasificacion");
            return View();
        }

        // POST: Rol_Cliente3/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rol_cliente,id_cliente,id_rol")] Rol_Cliente3 rol_Cliente3)
        {
            if (ModelState.IsValid)
            {
                db.Rol_Cliente3.Add(rol_Cliente3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", rol_Cliente3.id_cliente);
            ViewBag.id_rol = new SelectList(db.Rol3, "id_rol", "Clasificacion", rol_Cliente3.id_rol);
            return View(rol_Cliente3);
        }

        // GET: Rol_Cliente3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Cliente3 rol_Cliente3 = db.Rol_Cliente3.Find(id);
            if (rol_Cliente3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", rol_Cliente3.id_cliente);
            ViewBag.id_rol = new SelectList(db.Rol3, "id_rol", "Clasificacion", rol_Cliente3.id_rol);
            return View(rol_Cliente3);
        }

        // POST: Rol_Cliente3/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rol_cliente,id_cliente,id_rol")] Rol_Cliente3 rol_Cliente3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_Cliente3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id_cliente", "Nombre", rol_Cliente3.id_cliente);
            ViewBag.id_rol = new SelectList(db.Rol3, "id_rol", "Clasificacion", rol_Cliente3.id_rol);
            return View(rol_Cliente3);
        }

        // GET: Rol_Cliente3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Cliente3 rol_Cliente3 = db.Rol_Cliente3.Find(id);
            if (rol_Cliente3 == null)
            {
                return HttpNotFound();
            }
            return View(rol_Cliente3);
        }

        // POST: Rol_Cliente3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol_Cliente3 rol_Cliente3 = db.Rol_Cliente3.Find(id);
            db.Rol_Cliente3.Remove(rol_Cliente3);
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

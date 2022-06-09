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
    public class Rol_usuarioController : Controller
    {
        private ADBPrestamosEntities db = new ADBPrestamosEntities();

        // GET: Rol_usuario
        public ActionResult Index()
        {
            var rol_usuario = db.Rol_usuario.Include(r => r.Usuarios);
            return View(rol_usuario.ToList());
        }

        // GET: Rol_usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_usuario rol_usuario = db.Rol_usuario.Find(id);
            if (rol_usuario == null)
            {
                return HttpNotFound();
            }
            return View(rol_usuario);
        }

        // GET: Rol_usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre");
            return View();
        }

        // POST: Rol_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rol_usuario,rol,id_usuario")] Rol_usuario rol_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Rol_usuario.Add(rol_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre", rol_usuario.id_usuario);
            return View(rol_usuario);
        }

        // GET: Rol_usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_usuario rol_usuario = db.Rol_usuario.Find(id);
            if (rol_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre", rol_usuario.id_usuario);
            return View(rol_usuario);
        }

        // POST: Rol_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rol_usuario,rol,id_usuario")] Rol_usuario rol_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre", rol_usuario.id_usuario);
            return View(rol_usuario);
        }

        // GET: Rol_usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_usuario rol_usuario = db.Rol_usuario.Find(id);
            if (rol_usuario == null)
            {
                return HttpNotFound();
            }
            return View(rol_usuario);
        }

        // POST: Rol_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol_usuario rol_usuario = db.Rol_usuario.Find(id);
            db.Rol_usuario.Remove(rol_usuario);
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

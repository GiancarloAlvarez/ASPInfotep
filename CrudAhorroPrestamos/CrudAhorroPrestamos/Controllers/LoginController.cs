using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudAhorroPrestamos.Models;

namespace CrudAhorroPrestamos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

       
        public ActionResult Index()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Index(string User, string Pass)
        {
            using (ADBPrestamosEntities db = new ADBPrestamosEntities()) {

                var cUser = (from d in db.Usuarios
                             where d.nombre == User.Trim() && d.contrasena == Pass.Trim()
                             select d).FirstOrDefault();

                if (cUser == null) {

                    ViewBag.Error = "Usuario o contraseña incorrectos";
                    return View();
                    
                    
                }

                return RedirectToAction("Index","Home");
                Session["User"] = cUser;

            }

                return View();
        }
    }
}
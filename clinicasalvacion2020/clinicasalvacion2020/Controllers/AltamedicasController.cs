using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clinicasalvacion2020.Models;

namespace clinicasalvacion2020.Controllers
{
    public class AltamedicasController : Controller
    {
        private modelosContext db = new modelosContext();

        // GET: Altamedicas
        public ActionResult Index()
        {
            var altamedicas = db.Altamedicas.Include(a => a.Ingresos);
            return View(altamedicas.ToList());
        }

        public JsonResult dataingreso(int ingresoid)
        {
            var resultado = (from i in db.Ingresos
                             join p in db.Pacientes on i.pacienteid equals p.id
                             join h in db.Habitaciones on i.habitacionesid equals h.id
                             where (i.id == ingresoid)
                             select new
                             {
                                 nombre = p.nombre,
                                 id_ingreso = i.id,
                                 fecha = i.fecha_inicio,
                                 numero = h.numero,
                                 precio = h.precio
                             });

            return Json(resultado);
        }
        public ActionResult Create()
        {
            ViewBag.ingresoid = new SelectList(db.Ingresos, "id", "id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombrep,fechaingreso,habitacion,fechasalida,monto,ingresoid")] Altamedicas altamedicas)
        {
            if (ModelState.IsValid)
            {
                db.Altamedicas.Add(altamedicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ingresoid = new SelectList(db.Ingresos, "id", "id", altamedicas.ingresoid);
            return View(altamedicas);
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

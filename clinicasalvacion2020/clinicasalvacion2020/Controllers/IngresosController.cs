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
    public class IngresosController : Controller
    {
        private modelosContext db = new modelosContext();

        // GET: Ingresos
        public ActionResult Index()
        {
            var ingresos = db.Ingresos.Include(i => i.Habitaciones).Include(i => i.Pacientes);
            return View(ingresos.ToList());
        }

        // GET: Ingresos/Details/5


        // GET: Ingresos/Create
        public ActionResult Create()
        {
            ViewBag.habitacionesid = new SelectList(db.Habitaciones, "id", "numero");
            ViewBag.pacienteid = new SelectList(db.Pacientes, "id", "nombre");
            return View();
        }

        // POST: Ingresos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha_inicio,pacienteid,habitacionesid")] Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Ingresos.Add(ingresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.habitacionesid = new SelectList(db.Habitaciones, "id", "id", ingresos.habitacionesid);
            ViewBag.pacienteid = new SelectList(db.Pacientes, "id", "nombre", ingresos.pacienteid);
            return View(ingresos);
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

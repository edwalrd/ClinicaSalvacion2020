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
    public class Citas_MedicasController : Controller
    {
        private modelosContext db = new modelosContext();

        // GET: Citas_Medicas
        public ActionResult Index()
        {
            var citas_Medicas = db.Citas_Medicas.Include(c => c.Medico).Include(c => c.Pacientes);
            return View(citas_Medicas.ToList());
        }

        // GET: Citas_Medicas/Create
        public ActionResult Create()
        {
            ViewBag.medicoid = new SelectList(db.Medicos, "id", "nombre");
            ViewBag.pacienteid = new SelectList(db.Pacientes, "id", "nombre");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,hora,medicoid,pacienteid")] Citas_Medicas citas_Medicas)
        {
            if (ModelState.IsValid)
            {
                db.Citas_Medicas.Add(citas_Medicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicoid = new SelectList(db.Medicos, "id", "nombre", citas_Medicas.medicoid);
            ViewBag.pacienteid = new SelectList(db.Pacientes, "id", "nombre", citas_Medicas.pacienteid);
            return View(citas_Medicas);
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

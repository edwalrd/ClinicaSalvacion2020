using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clinicasalvacion2020;
using clinicasalvacion2020.Models;
using Rotativa;

namespace clinicasalvacion2020.Controllers
{
    public class MóduloConsultasController : Controller
    {
        // GET: MóduloConsultas
        private modelosContext db = new modelosContext();


        public JsonResult pacinete_json(string buscar, string seleciona)
        {
            filtro no;
            no = (filtro)Enum.Parse(typeof(filtro), "1");


            if (buscar == string.Empty)
            {
                return Json(db.Pacientes.ToList());
            }

            else if (seleciona == "nombre")
            {
                var resultadto1 = from x in db.Pacientes
                                  where x.nombre == buscar
                                  select x;


                return Json(resultadto1);
            }
            else if (seleciona == "cedula")
            {
                var resultado2 = from x in db.Pacientes
                                 where x.cedula == buscar
                                 select x;

                return Json(resultado2);

            }
            else if (seleciona == "0")
            {

                if (buscar == "SI" || buscar == "si")
                {


                    var resultado3 = from x in db.Pacientes
                                     where x.asegurados == 0
                                     select x;

                    return Json(resultado3);
                }

            }

            else if (seleciona == "1")
            {

                if (buscar == "NO" || buscar == "no" || buscar == "no" || buscar == "No")
                {


                    var resultado3 = from x in db.Pacientes
                                     where x.asegurados == no
                                     select x;

                    return Json(resultado3);
                }

            }

            return Json(db.Pacientes.ToList());
        }

        public ActionResult pacinte()
        {

            return View(db.Pacientes.ToList());

        }

        public ActionResult imprimir_paciente()
        {
            var impri = new ActionAsPdf("pacinte");

            return impri;
        }
        public JsonResult medico_json(string seleciona_medicos, string buscar_medico)
        {

            if (buscar_medico == string.Empty)
            {
                return Json(db.Medicos.ToList());
            }

            else if (seleciona_medicos == "nombrem")
            {
                var resultadto_medico1 = from m in db.Medicos
                                         where m.nombre == buscar_medico
                                         select m;


                return Json(resultadto_medico1);
            }
            else if (seleciona_medicos == "especialidad")
            {
                var resultadto_medico2 = from mm in db.Medicos
                                         where mm.Especialidad == buscar_medico
                                         select mm;

                return Json(resultadto_medico2);

            }
            return Json(db.Medicos.ToList());
        }


        public ActionResult medico()
        {

            return View(db.Medicos.ToList());

        }

        public ActionResult imprimir_medico()
        {
            var impri_medico = new ActionAsPdf("medico");

            return impri_medico;
        }
        public JsonResult json_habitacion(string seleciona_habitacion)
        {

            Tipos privada;
            Tipos doble;
            Tipos suite;

            doble = (Tipos)Enum.Parse(typeof(Tipos), "0");
            privada = (Tipos)Enum.Parse(typeof(Tipos), "1");
            suite = (Tipos)Enum.Parse(typeof(Tipos), "2");


            if (seleciona_habitacion == "doble")
            {
                var resultadto_medico1 = from h in db.Habitaciones
                                         where h.tipo == 0
                                         select h;


                return Json(resultadto_medico1);
            }
            else if (seleciona_habitacion == "privada")
            {
                var resultadto_habitacion2 = from hh in db.Habitaciones
                                             where hh.tipo == privada
                                             select hh;

                return Json(resultadto_habitacion2);

            }
            else if (seleciona_habitacion == "suite")
            {
                var resultadto_habitacion3 = from hhh in db.Habitaciones
                                             where hhh.tipo == suite
                                             select hhh;

                return Json(resultadto_habitacion3);

            }

            return Json(db.Habitaciones.ToList());
        }
        public ActionResult habitacion()
        {

            return View(db.Habitaciones.ToList());
        }

        public ActionResult imprimir_habitacion()
        {
            var impri_habitacion = new ActionAsPdf("habitacion");

            return impri_habitacion;
        }
        public JsonResult json_citas_medicas(string seleciona_cita, string buscar_cita)
        {

            if (buscar_cita == string.Empty)
            {

                return Json(db.Citas_Medicas.ToList());
            }

            else if (seleciona_cita == "doctor")
            {
                var resultado_cita = (from c in db.Citas_Medicas
                                      join p in db.Pacientes on c.pacienteid equals p.id
                                      join m in db.Medicos on c.medicoid equals m.id
                                      where (m.nombre == buscar_cita)
                                      select new
                                      {
                                          medico = m.nombre,
                                          paciente = p.nombre,
                                          fecha = c.fecha,
                                          hora = c.hora
                                      });

                return Json(resultado_cita);


            }
            else if (seleciona_cita == "paciente")
            {
                var resultado_cita2 = (from c in db.Citas_Medicas
                                       join p in db.Pacientes on c.pacienteid equals p.id
                                       join m in db.Medicos on c.medicoid equals m.id
                                       where (p.nombre == buscar_cita)
                                       select new
                                       {
                                           medico = m.nombre,
                                           paciente = p.nombre,
                                           fecha = c.fecha,
                                           hora = c.hora
                                       });

                return Json(resultado_cita2);

            }
            else if (seleciona_cita == "fecha")
            {
                var resultado_cita2 = (from c in db.Citas_Medicas
                                       join p in db.Pacientes on c.pacienteid equals p.id
                                       join m in db.Medicos on c.medicoid equals m.id
                                       where (c.fecha == buscar_cita)
                                       select new
                                       {
                                           medico = m.nombre,
                                           paciente = p.nombre,
                                           fecha = c.fecha,
                                           hora = c.hora
                                       });

                return Json(resultado_cita2);
            }


            return Json(db.Citas_Medicas.ToList());
        }

        public ActionResult Citas_Médicas()
        {

            var citas_Medicas = db.Citas_Medicas.Include(c => c.Medico).Include(c => c.Pacientes);
            return View(citas_Medicas.ToList());

        }

        public ActionResult imprimir_Médicas()
        {
            var impri_Médicas = new ActionAsPdf("Médicas");

            return impri_Médicas;
        }
        public JsonResult json_ingreso(string seleciona_ingreso, string buscar_ingreso)
        {

            if (buscar_ingreso == string.Empty)
            {

                return Json(db.Ingresos.ToList());
            }


            else if (seleciona_ingreso == "fecha")
            {
                var resultado_ingreso = (from i in db.Ingresos
                                         join h in db.Habitaciones on i.habitacionesid equals h.id
                                         join p in db.Pacientes on i.pacienteid equals p.id
                                         where (i.fecha_inicio == buscar_ingreso)
                                         select new
                                         {
                                             fecha = i.fecha_inicio,
                                             paciente = p.nombre,
                                             numero = h.numero
                                         });

                return Json(resultado_ingreso);
            }
            else if (seleciona_ingreso == "numero")
            {
                int num = Convert.ToInt16(buscar_ingreso.ToString());

                var resultado_ingreso1 = (from i in db.Ingresos
                                          join h in db.Habitaciones on i.habitacionesid equals h.id
                                          join p in db.Pacientes on i.pacienteid equals p.id
                                          where (h.numero == num)
                                          select new
                                          {
                                              fecha = i.fecha_inicio,
                                              paciente = p.nombre,
                                              numero = h.numero
                                          });
                return Json(resultado_ingreso1);
            }

            return Json(db.Ingresos.ToList());
        }
        public ActionResult Ingresos()
        {

            var ingresos = db.Ingresos.Include(i => i.Habitaciones).Include(i => i.Pacientes);
            return View(ingresos.ToList());

        }
        public ActionResult imprimir_Ingresos()
        {
            var impri_Ingresos = new ActionAsPdf("Ingresos");

            return impri_Ingresos;
        }
        public ActionResult Alta()
        {

            return View(db.Altamedicas.ToList());
        }


        public JsonResult json_altamedica(string seleciona_altamedica, string buscar_altamedica)
        {

            if (buscar_altamedica == string.Empty)
            {


                return Json(db.Altamedicas.ToList());
            }


            else if (seleciona_altamedica == "paciente")
            {
                var resultado_alta = from a in db.Altamedicas
                                     where a.nombrep == buscar_altamedica
                                     select a;


                return Json(resultado_alta);
            }
            else if (seleciona_altamedica == "fecha_ingreso")
            {
                var resultado_alta2 = from s in db.Altamedicas
                                      where s.fechaingreso == buscar_altamedica
                                      select s;

                return Json(resultado_alta2);
            }
            else if (seleciona_altamedica == "fecha_salida")
            {
                var resultado_alta3 = from d in db.Altamedicas
                                      where d.fechasalida == buscar_altamedica
                                      select d;

                return Json(resultado_alta3);
            }

            return Json(db.Altamedicas.ToList());

        }



        public JsonResult json_actualizar()
        {
            var all = db.Altamedicas
                      .GroupBy(x => x.nombrep)
                      .Select(g => new
                      {
                          minimo = g.Min(x => x.monto),
                          maximo = g.Max(x => x.monto),
                          sumatoria = g.Sum(x => x.monto),
                          promedio = g.Average(x => x.monto),
                          conteo = g.Count()
                      });

            return Json(all);
        }

        public ActionResult imprimir_Alta()
        {
            var impri_Alta = new ActionAsPdf("Alta");

            return impri_Alta;
        }


    }

}

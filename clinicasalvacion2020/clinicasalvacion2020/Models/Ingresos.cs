using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicasalvacion2020.Models
{
    public class Ingresos
    {
        public int id { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string fecha_inicio { get; set; }

        public int pacienteid { get; set; }
        [ForeignKey("pacienteid")]
        public Pacientes Pacientes { get; set; }

        public int habitacionesid { get; set; }
        [ForeignKey("habitacionesid")]
        public Habitaciones Habitaciones { get; set; }

    }
}
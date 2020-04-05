using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicasalvacion2020.Models
{
    public class Citas_Medicas
    {

        public int id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public string fecha { get; set; }

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public string hora { get; set; }


        public int medicoid { get; set; }
        [ForeignKey("medicoid")]
        public Medico Medico { get; set; }

        [Display(Name = "Paciente")]
        public int pacienteid { get; set; }
        [ForeignKey("pacienteid")]

        public Pacientes Pacientes { get; set; }

    }
}
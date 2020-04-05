using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace clinicasalvacion2020.Models
{
    public class Pacientes
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo se permite 30 caracteres")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo se permite 30 caracteres")]
        [Display(Name = "Cedula")]
        public string cedula { get; set; }
        [Display(Name = "Asegurado", Description = "Campo de seguros medicos")]
        public filtro asegurados { get; set; }

        //   public List<Ingresos> Ingresos { get; set; }

        //   public List<Citas_Medicas> citas { get; set; }

    }

    public enum filtro
    {
        Si, No
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace clinicasalvacion2020.Models
{
    public class Medico
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo se permite 30 caracteres")]

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo se permite 30 caracteres")]
        public string Exequatur { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo se permite 30 caracteres")]
        public string Especialidad { get; set; }

        //  public List<Citas_Medicas> Citas_s { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinicasalvacion2020.Models
{
    public class Habitaciones
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Numero")]
        public int numero { get; set; }
        [Display(Name = "Tipos")]
        public Tipos tipo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Precio")]
        public Double precio { get; set; }

        //  public List<Ingresos> Ingresos { get; set; }

    }
    public enum Tipos
    {
        Doble, privada, suite
    }
}
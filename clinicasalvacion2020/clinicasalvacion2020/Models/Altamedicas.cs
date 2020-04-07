using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace clinicasalvacion2020.Models
{
    public class Altamedicas
    {
        public int id { get; set; }

        [Display(Name = "Nombre de paciente")]
        [StringLength(30, ErrorMessage = "No puede pasar de 30 caracteres")]
        public string nombrep { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [StringLength(30, ErrorMessage = "No puede pasar de 30 caracteres")]

        public string fechaingreso { get; set; }

        [Display(Name = "Habitacion")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        [StringLength(30, ErrorMessage = "No puede pasar de 30 caracteres")]


        public string habitacion { get; set; }

        [Display(Name = "Fecha de salida")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        [StringLength(30, ErrorMessage = "No puede pasar de 30 caracteres")]


        public string fechasalida { get; set; }
        [Display(Name = "Monto")]
        public int monto { get; set; }

        public int ingresoid { get; set; }
        [ForeignKey("ingresoid")]
        public Ingresos Ingresos { get; set; }
    }
}
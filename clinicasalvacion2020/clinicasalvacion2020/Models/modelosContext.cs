using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace clinicasalvacion2020.Models
{
    public class modelosContext : DbContext
    {
        public modelosContext()
          : base("cadena1")
        {

        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }

        public DbSet<Citas_Medicas> Citas_Medicas { get; set; }

        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Altamedicas> Altamedicas { get; set; }

    }
}
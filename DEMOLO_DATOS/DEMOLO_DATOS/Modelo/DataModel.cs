using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DEMELO_DATOS.Modelo
{
    public class DataModel : DbContext
    {
        public DataModel() : base("DataModel") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //TABLAS DE LA BASE DE DATOS
        public DbSet<Empleado> Empleados { get; set; }


    }
}

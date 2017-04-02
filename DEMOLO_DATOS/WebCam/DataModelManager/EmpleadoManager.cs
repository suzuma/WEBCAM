using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DEMELO_DATOS.Modelo;

namespace WebCam.DataModelManager
{
    public class EmpleadoManager
    {
        public static void Guardar(Empleado nEmpleado) {
            try
            {
                using (var ctx = new DataModel()) {
                    if (nEmpleado.EmpleadoId > 0)
                    {
                        ctx.Entry(nEmpleado).State = System.Data.Entity.EntityState.Modified;
                    }
                    else {
                        ctx.Entry(nEmpleado).State = System.Data.Entity.EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }                
        }
    }
}

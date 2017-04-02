using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DEMELO_DATOS.Modelo;

namespace CONSULTA.DataModelManager
{
    public class EmpleadoManager
    {

        public static Empleado getByid(int id) {
            try
            {
                using (var ctx = new DataModel()) {
                    return ctx.Empleados.Where(r => r.EmpleadoId == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Empleado> getListado() {
            try
            {
                using(var ctx=new DataModel())
                {
                    return ctx.Empleados.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMELO_DATOS.Modelo
{
    [Table(name:"Empleados")]
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage ="Debe Ingresar el Nombre")]
        public String sNombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Apellido")]
        public String sApellido { get; set; }
        public String sImagen { get; set; }

    }
}

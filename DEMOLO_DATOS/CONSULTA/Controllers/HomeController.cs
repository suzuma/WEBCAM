using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CONSULTA.DataModelManager;

using System.Drawing;
using CONSULTA.Commun;
using DEMELO_DATOS.Modelo;

namespace CONSULTA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Datos = EmpleadoManager.getListado();
            return View();
        }
        //http://www.prideparrot.com/blog/archive/2012/8/uploading_and_returning_files
        public ActionResult GenerarImagen(int Id) {
            Empleado empleado = EmpleadoManager.getByid(Id);
            var bImagen = ToolImagen.Base64StringToBitmap(empleado.sImagen);
            byte[] byteArray = ToolImagen.ImageToByte(bImagen); 

            
            return File(byteArray, "image/jpeg");
        }
    }
}
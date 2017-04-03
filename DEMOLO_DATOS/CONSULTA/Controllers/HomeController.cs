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
      
    }
}
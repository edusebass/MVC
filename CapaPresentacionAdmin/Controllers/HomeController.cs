using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using ClassNegocio;
//using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        public JsonResult ListarUsuarios()
        {
            try
            {
                List<Usuario> oLista = new CN_Usuarios().Listar();
                Console.WriteLine($"Controller: Se obtuvieron {oLista.Count} usuarios");
                return Json(new { success = true, data = oLista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Controller.ListarUsuarios: {ex.Message}");
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
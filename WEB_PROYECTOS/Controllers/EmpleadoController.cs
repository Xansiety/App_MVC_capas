using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_PROYECTOS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmpleadoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            var empleados = EmpleadoCN.ListarEmpleados();
            //var proyectos = 
            return View(empleados);
        }


        public JsonResult ListarEmpleados()
        {
            try
            {
                var lstdata = EmpleadoCN.ListarEmpleados();
                return Json(new { ok = true, data = lstdata }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                //throw;
                return Json(new { ok = false, msg = "Ocurrio un error inesperado" }, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //verifica que el quien envia sea el mismom usuario evitar scrip maliciosos
        public ActionResult Crear(Empleado empleado)
        {
            try
            {

                //vañlidar desde lado servidor
                if (empleado.Nombres == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del empleado" }, JsonRequestBehavior.AllowGet);


                EmpleadoCN.Crear(empleado); // se instancia el medo de la capa de negocios


                System.Threading.Thread.Sleep(1000); //es para que la pagina se quede estancado unos segundos
                //como se hace una peticion desde json este se retorna de la sig forma
                //retotno lo correcto esi todo sale bien to redirect para redirigirme
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                //ModelState.AddModelError("", "Ocurrio un erro al agregar un proyecto: dta: " + ex.Message);
                ////throw;
                //return View();
                return Json(new { ok = false, msg = "Ocurrio un error inesperado" }, JsonRequestBehavior.AllowGet);

            }

        }


        public ActionResult Detalle(int id)
        {
            var empleado = EmpleadoCN.ObtenerEmpleados(id);

            return View(empleado);
        }



        public ActionResult Editar(int id)
        {
            var empleado = EmpleadoCN.ObtenerEmpleados(id);
            return View(empleado);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Empleado empleado)
        {

            try
            {
                EmpleadoCN.Editar(empleado);

                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                //throw;
                return Json(new { ok = false, msg = "Ocurrio un error inesperado" }, JsonRequestBehavior.AllowGet);

            }

        }//fin del metodo



        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                EmpleadoCN.Eliminar(id);

                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                //throw;
                return Json(new { ok = false, msg = "Ocurrio un error inesperado" }, JsonRequestBehavior.AllowGet);

            }
        }//fin eliminar
    }
}
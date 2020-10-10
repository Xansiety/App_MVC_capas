using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WEB_PROYECTOS.Controllers
{
    [Authorize(Roles = "Admin")]
    //[Authorize(Users = "Admin")]
    //[Authorize]
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var dptos = DepartamentoCN.ListarDepartamentos();

            return View(dptos);
        }

        [HttpGet]
        public ActionResult Crear() {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Departamento dpto)
        {
            try {

                if (dpto.NombreDepartamento == null) {
                    ModelState.AddModelError("", "Debes ingresar un nombre de departamento");
                    //throw;
                    return View(dpto);
                } 

                DepartamentoCN.Agregar(dpto);

                return RedirectToAction("Index");
            
            }
            catch (Exception ex) {
                ModelState.AddModelError("","Ocurrio un erro al agregar un departamento: dta: " + ex.Message);
                //throw;
                return View(dpto);
            }
        } //fin metodo crear


        public ActionResult GetDepartamento(int id) {

            try {

                var dpto = DepartamentoCN.GetDepartamento(id);

                return View(dpto);
            
            }
            catch (Exception ex) {
                ModelState.AddModelError("", "Ocurrio un erro al agregar un departamento: dta: " + ex.Message);
                //throw;
                return View();
            }

        }


        //edicion
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id);
           
            return View(dpto);
        }


        [HttpPost]
        public ActionResult Editar(Departamento dpto) {

            try {

                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debes ingresar un nombre de departamento");
                    //throw;
                    return View(dpto);
                }

                DepartamentoCN.Editar(dpto);
                return RedirectToAction("Index");


            }
            catch (Exception ex) {
                ModelState.AddModelError("", "Ocurrio un erro al agregar un departamento: dta: " + ex.Message);
                //throw;
                return View();
            }
        
        }



        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var dpto = DepartamentoCN.GetDepartamento(id.Value);

            return View(dpto);

        }


        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                DepartamentoCN.Eliminar(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex) {
                ModelState.AddModelError("", "Ocurrio un erro al eliminar un departamento: dta: " + ex.Message);
                //throw;
                return View();
            }

        }







    }
}
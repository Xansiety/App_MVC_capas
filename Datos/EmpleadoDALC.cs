using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpleadoDALC
    {
         public void Crear(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
            }
        }


        public List<Empleado> ListarEmpleados() 
        {

            using (var db = new ProyectosContext()) {

                return db.Empleado.ToList();

            }
        }

        public Empleado ObtenerEmpledos(int id) {

            using (var db = new ProyectosContext())
            {

                return db.Empleado.Find(id); //buscar Empleado por id

            }

        }


        public void Editar(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                //var p = db.Empleado.Find(empleado.ProyectoId);
                //p.NombreProyecto = empleado.NombreProyecto;
                //p.FechaInicio = empleado.FechaInicio;
                //p.FechaFin = empleado.FechaFin;
                
                db.SaveChanges();
            }
        } //fin


        public void Eliminar(int id) {
            using (var db = new ProyectosContext())
            {
                var p = db.Empleado.Find(id);
                db.Empleado.Remove(p);
                db.SaveChanges();
            }
        }


    }
}

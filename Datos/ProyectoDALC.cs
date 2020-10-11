using Entidad;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProyectoDALC
    {

        public void Crear(Proyecto proyecto)
        {
            using (var db = new ProyectosContext())
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
            }
        }


        public List<Proyecto> ListarProyectos()
        {

            using (var db = new ProyectosContext())
            {
                //carg difusa solo me tare lo relacionado a el se desactiva la crag difusa 
                db.Configuration.LazyLoadingEnabled = false;
                return db.Proyecto.ToList();

            }
        }


        public Proyecto ObtenerProyecto(int id)
        {

            using (var db = new ProyectosContext())
            {

                return db.Proyecto.Find(id); //buscar proyecto por id

            }

        }


        public void Editar(Proyecto proyecto)
        {
            using (var db = new ProyectosContext())
            {
                var p = db.Proyecto.Find(proyecto.ProyectoId);
                p.NombreProyecto = proyecto.NombreProyecto;
                p.FechaInicio = proyecto.FechaInicio;
                p.FechaFin = proyecto.FechaFin;

                db.SaveChanges();
            }
        } //fin


        public void Eliminar(int id)
        {
            using (var db = new ProyectosContext())
            {
                var p = db.Proyecto.Find(id);
                db.Proyecto.Remove(p);
                db.SaveChanges();
            }
        }


        public bool ExisteAsignacion(int proyectoId, int empleadoId)
        {
            using (var db = new ProyectosContext())
            {
                ////DEVUELVE EL PRIMERO
                ////var exist = db.ProyectoEmpleado.Where(p => p.ProyectoId == proyectoId && p.EmpleadoId == empleadoId)
                ////                                .FirstOrDefault();
                /// ////any devuelve verdadero o falso
                var exist = db.ProyectoEmpleado
                           .Any(p => p.ProyectoId == proyectoId && p.EmpleadoId == empleadoId);

                return exist;
            }

        }


        //asignacion de proyectos
        public void AsignarProyecto(int proyectoId, int empleadoId)
        {
            //SE CONTRUYE ENTIDAD PARA AGREGAR LOS DATOS Y SE ASIGNA LO QUE SE RECIBE
            var proyectoEmp = new ProyectoEmpleado
            {
                ProyectoId = proyectoId,
                EmpleadoId = empleadoId,
                FechaAlta = DateTime.Now
            };

            using (var db = new ProyectosContext())
            {                
                db.ProyectoEmpleado.Add(proyectoEmp);
                db.SaveChanges();
            }
        }

    }
}

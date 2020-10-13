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
                //.DATE solo compra la fech sin conatar la hora
                //var ToDay = DateTime.Now.Date;
                //return db.Proyecto.Where(p => p.FechaFin > ToDay).ToList();
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


        //asignacion de proyectos METODOS
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


        //VERIFICAR QUE NO SE ASIGNE A UN PROYECTO QUE Y NO ESTE ACTIVO
        public bool ProyectoActivo(int proyectoId)
        {
            using (var db = new ProyectosContext())
            {
                ////DEVUELVE EL PRIMERO
                ////var exist = db.ProyectoEmpleado.Where(p => p.ProyectoId == proyectoId && p.EmpleadoId == empleadoId)
                ////                                .FirstOrDefault();
                /// ////any devuelve verdadero o falso
                var ToDay = DateTime.Now.Date;

                var proyectoActivo = db.Proyecto
                           .Any(p => p.ProyectoId == proyectoId && p.FechaFin > ToDay);

                return proyectoActivo;
            }


        }

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
        }//fin del metodo


        public List<ProyectoEmpleadoViewModel> ListarAsignaciones()
        {
            try
            {
                string Sql = @"Select pe.ProyectoId,p.NombreProyecto,pe.EmpleadoId, e.Apellidos, e.Nombres, pe.FechaAlta
                                from ProyectoEmpleado pe
                                inner join Proyecto p on pe.ProyectoId = p.ProyectoId
                                inner join Empleado e on e.EmpleadoId = pe.EmpleadoId";
                using (var db = new ProyectosContext())
                {

                    return db.Database.SqlQuery<ProyectoEmpleadoViewModel>(Sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public void EliminarAsignacion(int proyectoId, int empleadoId)
        {
            try
            {
                using (var db = new ProyectosContext())
                {
                    var EmpProy = db.ProyectoEmpleado
                        .Where(e => e.ProyectoId == proyectoId && e.EmpleadoId == empleadoId)
                        .FirstOrDefault();

                    db.ProyectoEmpleado.Remove(EmpProy); //eliminar la asignacion
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}

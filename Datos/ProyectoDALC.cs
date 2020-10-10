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

            using (var db = new ProyectosContext()) {

                return db.Proyecto.ToList();

            }
        }

        public Proyecto ObtenerProyecto(int id) {

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


        public void Eliminar(int id) {
            using (var db = new ProyectosContext())
            {
                var p = db.Proyecto.Find(id);
                db.Proyecto.Remove(p);
                db.SaveChanges();
            }
        }

    }
}

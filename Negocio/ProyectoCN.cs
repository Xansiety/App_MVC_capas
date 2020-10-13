using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProyectoCN
    {
        //instanciar db
        private static ProyectoDALC obj = new ProyectoDALC();

        //public static List<Proyecto> ListarProyectos()
        //LISTAR DESDE STRORE PROCEDURE
        //public static List<SpListarProyectos_Result> ListarProyectos()
        public static List<Proyecto> ListarProyectos()
        {
            return obj.ListarProyectos();

        }

        public static void Crear(Proyecto proyecto)
        {
            obj.Crear(proyecto);
        }


        public static Proyecto ObtenerProyecto(int id)
        {

            return obj.ObtenerProyecto(id);
        }


        public static void Editar(Proyecto proyecto)
        {
            obj.Editar(proyecto);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }


        //metodos para la asignacion
        public static bool ExisteAsignacion(int proyectoId, int empleadoId)
        {
            return obj.ExisteAsignacion(proyectoId, empleadoId);
        }

        public static bool ProyectoActivo(int proyectoId)
        {
            return obj.ProyectoActivo(proyectoId);
        }


        public static void AsignarProyecto(int proyectoId, int empleadoId)
        {
            obj.AsignarProyecto(proyectoId, empleadoId);
        }


        public static List<ProyectoEmpleadoViewModel> ListarAsignaciones()
        {

            return obj.ListarAsignaciones();
        }


        public static void EliminarAsignacion(int proyectoId, int empleadoId)
        {
            obj.EliminarAsignacion(proyectoId, empleadoId);
        }


    }
}

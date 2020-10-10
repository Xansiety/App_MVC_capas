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

    }
}

using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class EmpleadoCN
    {
        //instanciar db
        private static EmpleadoDALC obj = new EmpleadoDALC();

        public static List<EmpleadoVM> ListarEmpleados()
        {
            return obj.ListarEmpleados();

        }

        public static void Crear(Empleado empleado)
        {
            obj.Crear(empleado);
        }


        public static Empleado ObtenerEmpleados(int id)
        {

            return obj.ObtenerEmpledos(id);
        }


        public static void Editar(Empleado empleado)
        {
            obj.Editar(empleado);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }

    }
}

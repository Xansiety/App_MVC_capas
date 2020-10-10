using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
   public class EmpleadoVM
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }        
        //ESTO SIRVE PARA CONCATENAR DE MANER MAS SECILLA Y NO EN EL CODIGO LOS NOMBRES Y APELLIDOS
        public string NombreCompleto { get { return $"{ Apellidos } { Nombres }"; } }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }

    }
}

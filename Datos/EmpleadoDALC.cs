using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


        public List<EmpleadoVM> ListarEmpleados()
        {
            //uso de ViewModel para poder realiza las consultas en SQL
            string sql = @"select e.EmpleadoId, e.Nombres, e.Apellidos , e.Direccion, e.Email, e.Celular,e.DepartamentoId, d.NombreDepartamento
                        from empleado e
                        inner join Departamento d on e.DepartamentoId = d.DepartamentoId";

            using (var db = new ProyectosContext())
            {
                //return db.Empleado.ToList();
                return db.Database.SqlQuery<EmpleadoVM>(sql).ToList();
            }
        }

        public Empleado ObtenerEmpledos(int id)
        {

            //using (var db = new ProyectosContext())
            //{

            //    return db.Empleado.Find(id); //buscar Empleado por id

            //}
            //QUERY CON PARAMETROS
            string sql = @"select *  from empleado where EmpleadoId = @id";

            using (var db = new ProyectosContext())
            {

                //  return db.Empleado.Find(id); //buscar Empleado por id
                return db.Database.SqlQuery<Empleado>(sql,
                    new SqlParameter("@id", id)).FirstOrDefault();

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


        public void Eliminar(int id)
        {
            using (var db = new ProyectosContext())
            {
                var p = db.Empleado.Find(id);
                db.Empleado.Remove(p);
                db.SaveChanges();
            }
        }


    }
}

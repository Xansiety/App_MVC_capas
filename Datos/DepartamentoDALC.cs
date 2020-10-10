using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DepartamentoDALC
    {

        public void Agregar(Departamento dpto) {

            using (var db = new ProyectosContext())
            {
                //con esto se ingresa a la BD
                db.Departamento.Add(dpto);
                db.SaveChanges();
            }
        
        }

        //se importa entidad
        public List<Departamento> ListarDepartamentos() {

            using (var db = new ProyectosContext()) {

                //carg difusa solo me tare lo relacionado a el se desactiva la crag difusa 
                db.Configuration.LazyLoadingEnabled = false; 

                return db.Departamento.ToList(); //retorna todo lo de la tabla

            } 
        }



        public Departamento GetDepartamento(int id) {

            using (var db = new ProyectosContext()) {

                //var depto = db.Departamento.Find(id); //linq by find 
                //return depto;
                var depto = db.Departamento.Where(d => d.DepartamentoId == id).FirstOrDefault();
                return depto;
            }
        
        }


        //editar registro
        public void Editar(Departamento dpto ) {
            using (var db = new ProyectosContext())
            {

                var d = db.Departamento.Find(dpto.DepartamentoId);
                d.NombreDepartamento = dpto.NombreDepartamento;  //reemplazame el nombre actual por el qie te mando
                
                db.SaveChanges();

            }
            
        }


        //Eliminar

        public void Eliminar(int id) {

            using (var db = new ProyectosContext()) {

                var dpto = db.Departamento.Find(id);

                db.Departamento.Remove(dpto);
                db.SaveChanges();

            }
        
        }



    }
}

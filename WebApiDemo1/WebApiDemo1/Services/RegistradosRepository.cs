using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiDemo1.Interfaces;
using WebApiDemo1.Models;

namespace WebApiDemo1.Services
{
    public class RegistradosRepository : IRegistrados
    {
       
        public IEnumerable<Registrado> ListRegistrados
        {
            get { return CargarRegistrados(); }

        }

        public IEnumerable<Registrado> DatosDeRegistrado(string Identificacion)
        {
            return CargaDatosByIdentificacion(Identificacion);    
        }


        public IEnumerable<Registrado> DatosDeRegistrado2(int IdRegistrado, string identificacion)
        {

            return CargaDatosByIdentificacionById(IdRegistrado, identificacion);

        }

        ///Accedo al dbcontext - acceder a la capa de datos

        //Devuelve todos los registros
        public List<Registrado> CargarRegistrados()
        {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.ToList();
            }
        }

        //Devolver registro por parametro de entrada
       public List<Registrado>CargaDatosByIdentificacion(string identificacion)
       {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(a=> a.Identificacion == identificacion).ToList();
            }
       }

        public List<Registrado> CargaDatosByIdentificacionById(int IdRegistrado, string identificacion)
        {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(a => a.IdRegistrado == IdRegistrado 
                && a.Identificacion == identificacion).ToList();
            }
        }

        public void InsertRegistrado(Registrado NewItem)
        {
            using (var context = new DBRegistradosContext() )
            {
                context.Registrados.Add(NewItem);
                context.SaveChanges();
            }
        }

    }
}

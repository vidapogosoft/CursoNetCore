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

    }
}

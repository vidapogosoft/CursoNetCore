using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiDemo1.Interfaces;
using WebApiDemo1.Models;

using WebApiDemo1.Entidades;   

namespace WebApiDemo1.Services
{
    public class RegistradosRepository : IRegistrados
    {
        //private List<Registrado> ListRegistrado;

        public IEnumerable<Registrado> ListRegistrados
        {
            get { return CargarRegistrados(); }

        }

        public IEnumerable<clsDatosRegistrados> ListDatosEmpresaRegistrados
        {
            get { return CargaDatosRegistradosEmpresas(); }
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


        public void DeleteRegistrado(int IdRegistrado)
        {
            using (var context = new DBRegistradosContext())
            {
                var Registro = context.Registrados.Where(a=> a.IdRegistrado == IdRegistrado).FirstOrDefault();

                if (Registro != null)
                {
                    context.Registrados.Remove(Registro);
                    context.SaveChanges();
                }

            }
        }

        public List<Registrado> ItemExists(int IdRegistrado)
        {
            using (var context = new DBRegistradosContext())
            {
                return  context.Registrados.Where(z => z.IdRegistrado == IdRegistrado).ToList();
            }

        }

        public void UpdateRegistrado(Registrado Item)
        {
            using (var context = new DBRegistradosContext())
            {

                var registro = context.Registrados.Where(a => a.IdRegistrado == Item.IdRegistrado).ToList();

                if (registro.Count > 0)
                {
                    foreach(Registrado reg in registro)
                    {
                        reg.Apellidos = Item.Apellidos;
                        reg.Nombres = Item.Nombres;
                        reg.NombresCompletos = Item.NombresCompletos;
                        reg.Identificacion = Item.Identificacion;

                        context.SaveChanges();
                    }
                }
            }
         }


        public List<clsDatosRegistrados> CargaDatosRegistradosEmpresas()
        {

            using (var ctx = new DBRegistradosContext())
            {
                var x = (

                    from a in ctx.Registrados
                    join b in ctx.EmpresaRegistrados on a.IdRegistrado equals b.IdRegistrado
                    join c in ctx.Empresas on b.IdEmpresa equals c.IdEmpresa
                    where b.Estado == "ACTIVO"
                    orderby b.IdEmpresaRegistrado descending

                    select new clsDatosRegistrados()
                    {
                        IdRegistrado = a.IdRegistrado,
                        Identificacion = a.Identificacion,
                        NombresCompletos = a.NombresCompletos,
                        NombresEmpresa = c.NombrEmpresa,
                        EstadoRelacionEmpresa = b.Estado
                    }

                    ).ToList();

                return x;
            }
        }
    }
}

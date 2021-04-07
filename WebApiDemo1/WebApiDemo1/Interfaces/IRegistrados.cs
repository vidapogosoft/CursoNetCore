using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiDemo1.Models;

using WebApiDemo1.Entidades;

namespace WebApiDemo1.Interfaces
{
    public interface IRegistrados
    {
        IEnumerable<Registrado> ListRegistrados { get;  }

        IEnumerable<Registrado> DatosDeRegistrado(string Identificacion);

        IEnumerable<Registrado> DatosDeRegistrado2(int IdRegistrado, string identificacion);

        void InsertRegistrado(Registrado NewItem);
        void UpdateRegistrado(Registrado Item);

        void DeleteRegistrado(int IdRegistrado);

        bool ItemExists(int IdRegistrado );

        IEnumerable<clsDatosRegistrados> ListDatosEmpresaRegistrados { get; }
    }
}

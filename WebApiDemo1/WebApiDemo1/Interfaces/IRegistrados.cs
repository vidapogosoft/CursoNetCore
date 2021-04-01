using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiDemo1.Models;

namespace WebApiDemo1.Interfaces
{
    public interface IRegistrados
    {
        IEnumerable<Registrado> ListRegistrados { get;  }

        IEnumerable<Registrado> DatosDeRegistrado(string Identificacion);
    }
}

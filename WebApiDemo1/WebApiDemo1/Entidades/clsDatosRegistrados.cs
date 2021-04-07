using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo1.Entidades
{
    public class clsDatosRegistrados
    {
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }
      
        public string NombresCompletos { get; set; }

        public string NombresEmpresa { get; set; }

        public string EstadoRelacionEmpresa { get; set; }

        public string ProyectosPorEmpresa { get; set; }
        public string FechaInicioProyecto { get; set; }
        public string FechaFinProyecto { get; set; }

    }
}

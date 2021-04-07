using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiDemo1.Models
{
    public partial class EmpresaRegistrado
    {
        public int IdEmpresaRegistrado { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdRegistrado { get; set; }
        public string Estado { get; set; }
    }
}

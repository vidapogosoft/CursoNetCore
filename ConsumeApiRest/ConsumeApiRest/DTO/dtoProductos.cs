using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApiRest.DTO
{
    public class dtoProductos
    {


        public string id { get; set; }
        public string nombre { get; set; }
        public string fechaExpiracion { get; set; }
        public string fechaAlerta { get; set; }
        public string precio { get; set; }
        public string comentarios { get; set; }

    }
}

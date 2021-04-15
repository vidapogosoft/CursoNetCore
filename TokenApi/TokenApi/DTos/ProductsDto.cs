using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenApi.DTos
{
    public class ProductsDto
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public DateTime FechaAlerta { get; set; }

        public decimal Precio { get; set; }

        public string Comentarios { get; set; }
    }
}

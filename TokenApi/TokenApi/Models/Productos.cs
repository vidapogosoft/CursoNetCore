using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenApi.Models
{
    public class Productos
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public DateTime FechaAlerta { get; set; }

        public decimal Precio { get; set; }

        public string Comentarios { get; set; }

    }
}

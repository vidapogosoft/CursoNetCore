using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiDemo1.Models
{
    public partial class Registrado
    {
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }
    }
}

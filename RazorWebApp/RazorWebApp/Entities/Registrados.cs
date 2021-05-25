using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWebApp.Entities
{
    public class Registrados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistrado { get; set; }
      
        public string Identificacion { get; set; }
       
        public string Nombres { get; set; }
       
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }

    }
}

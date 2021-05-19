using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace RazorWebApp.Entities
{
    public class Registrados
    {

        public string idRegistrado { get; set; }
        [Required]
        public string identificacion { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellidos { get; set; }
        public string nombresCompletos { get; set; }

    }
}

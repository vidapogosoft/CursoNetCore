using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using BlazorWA1.Shared.Models;

namespace BlazorWA1.Server.DataAccess
{
    public class RegistradoDataAccessLayer
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Registrados> GetAllRegistrados()
        {
            return db.Registrados.ToList();

        }


    }
}

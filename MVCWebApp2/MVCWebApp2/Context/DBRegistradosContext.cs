using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MVCWebApp2.Models;


namespace MVCWebApp2.Context
{
    public class DBRegistradosContext: DbContext
    {

        public DBRegistradosContext(DbContextOptions<DBRegistradosContext> options) : base(options)
        { 
            
        }

        public DbSet<Registrado> Registrados { get; set; }

    }
}

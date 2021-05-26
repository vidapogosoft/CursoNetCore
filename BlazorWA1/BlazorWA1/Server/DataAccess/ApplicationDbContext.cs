using System;
using Microsoft.EntityFrameworkCore;


using BlazorWA1.Shared.Models;


namespace BlazorWA1.Server.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
     

        public virtual DbSet<Registrados> Registrados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("User= sa; Password= Ctek2314;Persist Security Info=False;Initial Catalog=DBRegistrados;Data Source=(local)");
            }
        }


    }
}

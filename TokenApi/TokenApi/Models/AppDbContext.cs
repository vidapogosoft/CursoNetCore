using System;
using Microsoft.EntityFrameworkCore;

namespace TokenApi.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>(productos =>
            {
                productos.HasKey(s => s.Id);
                productos.Property(s => s.Nombre).IsRequired();
                productos.Property(s => s.FechaExpiracion).IsRequired();
                productos.Property(s => s.FechaAlerta).IsRequired();
                productos.Property(s => s.Precio);
                productos.Property(s => s.Comentarios);
            });

            modelBuilder.Entity<Productos>().HasData
            (
                new Productos
                {
                    Id = Guid.Parse("ae5a685c-ba5f-4d43-bc58-dde1f05d5024"),
                    Nombre = "Monitor HP",
                    FechaExpiracion = DateTime.Parse("01/01/2022"),
                    FechaAlerta = DateTime.Parse("01/01/2022"),
                    Precio = 150,
                    Comentarios = "25 pulg 4k"
                },

                new Productos
                {
                    Id = Guid.Parse("fc197cd7-32f9-4ccc-be69-e812009d0e1c"),
                    Nombre = "Laptop HP 15",
                    FechaExpiracion = DateTime.Parse("01/01/2022"),
                    FechaAlerta = DateTime.Parse("01/01/2022"),
                    Precio = 150,
                    Comentarios = "AMD ATHLON 16GB"
                },

                new Productos
                {
                    Id = Guid.Parse("6fa0ba69-8852-4722-a580-2bebc2623a7a"),
                    Nombre = "Monitor DEL",
                    FechaExpiracion = DateTime.Parse("01/01/2022"),
                    FechaAlerta = DateTime.Parse("01/01/2022"),
                    Precio = 150,
                    Comentarios = "23 pulg FULL HD"
                }
            );

        }


    }
}

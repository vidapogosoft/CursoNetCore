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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Registrados");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");

        }

    }
}

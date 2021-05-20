using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using RazorWebApp.Data;
using RazorWebApp.Interfaces;
using RazorWebApp.Entities;

namespace RazorWebApp.Repositories
{
    public class RegistradosRepositoryAsync : GenericRepositoryAsync<Registrados>, IRegistradosRepositoryAsync
    {
        private readonly DbSet<Registrados> _Registrados;

        public RegistradosRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Registrados = dbContext.Set<Registrados>();
        }


    }
}

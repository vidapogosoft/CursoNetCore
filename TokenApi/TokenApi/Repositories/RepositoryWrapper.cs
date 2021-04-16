using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using TokenApi.Models;

namespace TokenApi.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _repoContext;

        private IProductsRepository _products;

        public RepositoryWrapper(AppDbContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _repoContext.Database.EnsureCreated();
            _mapper = mapper;
        }

        public IProductsRepository Productos
        {

            get
            {

                if (_products == null)
                {
                    _products = new ProductsRepository(_repoContext, _mapper);
                }

                return _products;

            }

        }

       
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}

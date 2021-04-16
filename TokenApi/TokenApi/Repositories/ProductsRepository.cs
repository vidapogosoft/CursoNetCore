using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TokenApi.Models;
using TokenApi.DTos;
using AutoMapper;


namespace TokenApi.Repositories
{
    public class ProductsRepository : RepositoryBase<Productos>, IProductsRepository
    {

        private readonly IMapper _mapper;

        public ProductsRepository(AppDbContext repositoryContext, IMapper mapper)
           : base(repositoryContext)
        {
            _mapper = mapper;
        }

        void IProductsRepository.CreateProduct(ProductsDto product)
        {
            throw new NotImplementedException();
        }

        void IProductsRepository.DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductsDto>> GetAllProductsAsync()
        {
            var product = await FindAll().OrderBy(x => x.Nombre).ToListAsync();
            var productResult = _mapper.Map<IEnumerable<ProductsDto>>(product);

            return productResult;
        }

        Task<ProductsDto> IProductsRepository.GetProductByIdAsync(Guid ProdcuctId)
        {
            throw new NotImplementedException();
        }

        void IProductsRepository.UpdateProduct(Guid id, ProductsDto product)
        {
            throw new NotImplementedException();
        }
    }
}

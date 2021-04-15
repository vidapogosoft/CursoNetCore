using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        Task<IEnumerable<ProductsDto>> IProductsRepository.GetAllProductsAsync()
        {
            throw new NotImplementedException();
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

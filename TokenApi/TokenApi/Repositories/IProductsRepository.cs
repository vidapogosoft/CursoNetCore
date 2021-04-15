using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TokenApi.DTos;
using TokenApi.Models;

namespace TokenApi.Repositories
{
    public interface IProductsRepository : IRepositoryBase<Productos>
    {

        Task<IEnumerable<ProductsDto>> GetAllProductsAsync();

        Task<ProductsDto> GetProductByIdAsync(Guid ProdcuctId);

        void CreateProduct(ProductsDto product);

        void UpdateProduct(Guid id, ProductsDto product);

        void DeleteProduct(Guid id);

    }
}

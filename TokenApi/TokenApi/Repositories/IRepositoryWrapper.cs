using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenApi.Repositories
{
    public interface IRepositoryWrapper
    {
        IProductsRepository Productos { get; }

        Task SaveAsync();
    }
}

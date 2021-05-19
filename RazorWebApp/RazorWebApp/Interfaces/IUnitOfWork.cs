using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> Commit();
    }
}

using Dafontana.Domain.Entities;
using Dafontana.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Dafontana.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Sale> SalesRepository { get; }
        IGenericRepository<DetailSale> SaleDetailsRepository { get; }
        IGenericRepository<Product> ProductsRepository { get; }
        IGenericRepository<Store> StoresRepository { get; }
        Task SaveAsync();
    }
}

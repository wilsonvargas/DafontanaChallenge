using Dafontana.Domain;
using Dafontana.Domain.Entities;
using Dafontana.Infrastructure.Repositories;
using Dafontana.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Dafontana.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DafontanaDbContext _context;
        private SalesRepository salesRepository;
        private SaleDetailsRepository saleDetailsRepository;
        private ProductsRepository productsRepository;
        private StoresRepository storesRepository;

        public UnitOfWork(DafontanaDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Sale> SalesRepository
        {
            get
            {
                if (salesRepository == null)
                {
                    salesRepository = new SalesRepository(_context);
                }
                return salesRepository;
            }
        }

        public IGenericRepository<DetailSale> SaleDetailsRepository
        {
            get
            {
                if (saleDetailsRepository == null)
                {
                    saleDetailsRepository = new SaleDetailsRepository(_context);
                }
                return saleDetailsRepository;
            }
        }

        public IGenericRepository<Product> ProductsRepository
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new ProductsRepository(_context);
                }
                return productsRepository;
            }
        }

        public IGenericRepository<Store> StoresRepository
        {
            get
            {
                if (storesRepository == null)
                {
                    storesRepository = new StoresRepository(_context);
                }
                return storesRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

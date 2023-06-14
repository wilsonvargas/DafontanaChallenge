using Dafontana.Domain.Entities;
using Dafontana.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Dafontana.Infrastructure.Repositories
{
    public class ProductsRepository : GenericRepository<Product>
    {
        public ProductsRepository(DbContext _context) : base(_context)
        { }

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }
    }
}

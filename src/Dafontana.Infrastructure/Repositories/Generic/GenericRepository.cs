using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dafontana.Infrastructure.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync();

        }

        public async Task<TEntity> Find(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> List(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}

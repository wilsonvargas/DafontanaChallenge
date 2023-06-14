using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Dafontana.Infrastructure.Repositories.Generic
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> Find(int id);

        Task<List<TEntity>> List(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}

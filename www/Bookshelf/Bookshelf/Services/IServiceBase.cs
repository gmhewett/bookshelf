namespace Bookshelf.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Bookshelf.Models;

    public interface IServiceBase<TEntity> : IDisposable where TEntity : BookshelfModel
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> GetByIdAsync(int id);

        Task UpdateAsync(TEntity entity);

        Task CreateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(int id);
    }
}
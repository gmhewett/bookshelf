namespace Bookshelf.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Bookshelf.Models;

    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BookshelfModel
    {
        private readonly BookshelfDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public ServiceBase(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await (orderBy?.Invoke(query).ToListAsync() ?? query.ToListAsync());
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.EntityExists(entity.Id))
                {
                    throw new KeyNotFoundException();
                }

                throw;
            }
        }

        public async Task CreateAsync(TEntity entity)
        {
            this.dbSet.Add(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            TEntity entity = await this.dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            this.dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        private async Task<bool> EntityExists(int id)
        {
            return await this.dbSet.CountAsync(e => e.Id == id) > 0;
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
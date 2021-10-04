using _09_30_CompaniesEmployeesWebApi.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        // string includeProperties - properties, separated with ','
        public virtual async Task<List<TEntity>> GetAllAsync(string includeProperties)
        {
            return await IncludeProperties(_dbSet, includeProperties).ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // string includeProperties - properties, separated with ','
        public virtual async Task<List<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties)
        {
            return await IncludeProperties(_dbSet.Where(predicate), includeProperties).ToListAsync();
        }

        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        private IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> query, string properties)
        {
            if (!string.IsNullOrWhiteSpace(properties))
            {
                foreach (var property in properties.Split(',', StringSplitOptions.TrimEntries))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}

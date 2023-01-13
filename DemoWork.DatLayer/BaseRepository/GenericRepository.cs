using DemoWork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.DataLayer.BaseRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DemoWorkContext _dbContext;
        public DbSet<T> _dbSet;

        public GenericRepository(DemoWorkContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = this._dbContext.Set<T>();
        }


        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> EditAsync(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }


        public Task DeleteManyAsync(Expression<Func<T, bool>> filter)
        {
            var entities = _dbSet.Where(filter);

            _dbSet.RemoveRange(entities);

            return Task.CompletedTask;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetManyAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? top = null,
            int? skip = null,
            params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties.Length > 0)
            {
                query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (top.HasValue)
            {
                query = query.Take(top.Value);
            }

            return await query.ToListAsync();
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.DataLayer.BaseRepository
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> AddAsync(T entity);
        Task<T> EditAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteManyAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Guid id);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          int? top = null,
                                          int? skip = null,
                                          params string[] includeProperties
                                          );


    }
}

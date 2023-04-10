using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;
using System.Linq.Expressions;

namespace MovieStore.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {

        private readonly ApplicationDbContext _context;
        protected DbSet<T> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task<bool> Delete(T entity)
        {
            return await Save() > 0;
        }

        public async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(
                    Expression<Func<T, TResult>> select, 
                    Expression<Func<T, bool>> where, Func<IQueryable<T>, 
                    IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>, 
                    IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                return await orderby(query).Select(select).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(
                    Expression<Func<T, TResult>> select,
                    Expression<Func<T, bool>> where, Func<IQueryable<T>,
                    IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>,
                    IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                return await orderby(query).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return await Save() > 0;
        }
    }
}

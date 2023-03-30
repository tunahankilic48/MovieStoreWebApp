using Microsoft.EntityFrameworkCore.Query;
using MovieStore.Domain.Entities;
using System.Linq.Expressions;

namespace MovieStore.Domain.Repositories
{
    /// <summary>
    /// Repository Design Pattern
    /// This pattern is a design pattern used to prevent code duplication and increase reusability when using ORM tools that are in constant communication with the database, such as Entity Framework.<para/>
    ///In the Base Repository interface, it is aimed to be used for different classes by using the generic structure.<para/>
    ///In addition, thanks to this pattern, we minimize the intervention to the database in the controls and force the developer to use only these commands.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
    );

        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );
        Task<List<TEntity>> GetDefaults(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetDefault(Expression<Func<TEntity, bool>> expression);

        Task<bool> Any(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Save New <typeparamref name="TEntity" />
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Add(TEntity entity);

        /// <summary>
        /// Update <typeparamref name="TEntity" />
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity);

        /// <summary>
        /// Delete <typeparamref name="TEntity" />
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<bool> Delete(TEntity entity);

        Task<int> Save();
    }
}

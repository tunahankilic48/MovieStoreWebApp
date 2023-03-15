using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Linq.Expressions;

namespace MovieStore.Repository.Abstract
{
    /// <summary>
    /// Repository Design Pattern
    /// This pattern is a design pattern used to prevent code duplication and increase reusability when using ORM tools that are in constant communication with the database, such as Entity Framework.<para/>
    ///In the Base Repository interface, it is aimed to be used for different classes by using the generic structure.<para/>
    ///In addition, thanks to this pattern, we minimize the intervention to the database in the controls and force the developer to use only these commands.
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IBaseRepository<Entity> where Entity : class
    {
        /// <summary>
        /// List all <typeparamref name="Entity" />
        /// </summary>
        /// <returns></returns>
        ICollection<Entity> GetAll();

        /// <summary>
        /// List <typeparamref name="Entity" /> acording to the expression parameter
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        ICollection<Entity> GetDefault(Expression<Func<Entity, bool>> exp);

        /// <summary>
        /// Get <typeparamref name="Entity" /> acording to Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Entity GetById(int id);

        /// <summary>
        /// Save New <typeparamref name="Entity" />
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(Entity entity);

        /// <summary>
        /// Update <typeparamref name="Entity" />
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(Entity entity);

        /// <summary>
        /// Delete <typeparamref name="Entity" />
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(int id);
        
        int Save();
    }
}

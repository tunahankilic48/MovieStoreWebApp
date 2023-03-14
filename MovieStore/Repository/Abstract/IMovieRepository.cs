using MovieStore.Models.Entities;

namespace MovieStore.Repository.Abstract
{
    /// <summary>
    /// Repository Design Pattern
    /// This pattern is a design pattern used to prevent code duplication and increase reusability when using ORM tools that are in constant communication with the database, such as Entity Framework.<para/>
    ///In the Base Repository interface, it is aimed to be used for different classes by using the generic structure.<para/>
    ///In addition, thanks to this pattern, we minimize the intervention to the database in the controls and force the developer to use only these commands.
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IMovieRepository : IBaseRepository<Movie>
    {
    }
}

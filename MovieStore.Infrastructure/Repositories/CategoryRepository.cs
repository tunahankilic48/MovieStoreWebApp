using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Infrastructure.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

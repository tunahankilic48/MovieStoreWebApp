using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Infrastructure.Repositories
{
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

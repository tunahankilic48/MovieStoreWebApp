using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Infrastructure.Repositories
{
    public class StarringRepository : BaseRepository<Starring>, IStarringRepository
    {
        public StarringRepository(ApplicationDbContext context) : base(context)
        {            
        }
    }
}

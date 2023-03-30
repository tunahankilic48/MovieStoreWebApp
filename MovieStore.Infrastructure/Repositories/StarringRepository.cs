using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Infrastructure.Repositories
{
    internal class StarringRepository : BaseRepository<Starring>, IStarringRepository
    {
        public StarringRepository(ApplicationDbContext context) : base(context)
        {            
        }
    }
}

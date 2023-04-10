using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Infrastructure.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

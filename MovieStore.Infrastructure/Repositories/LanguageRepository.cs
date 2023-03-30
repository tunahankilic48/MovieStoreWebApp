using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Infrastructure.Repositories
{
    internal class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

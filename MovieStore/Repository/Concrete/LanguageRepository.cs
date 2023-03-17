using Microsoft.EntityFrameworkCore;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using System.Linq.Expressions;

namespace MovieStore.Repository.Concrete
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly IMovieDbContext _context;
        public LanguageRepository(IMovieDbContext context)
        {
            _context = context;
        }
        public bool Add(Language entity)
        {
            _context.Languages.Add(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            _context.Languages.Remove(GetById(id));
            return Save() > 0;
        }

        public ICollection<Language> GetAll()
        {
            return _context.Languages.Include(x => x.OriginalLanguageOfMovies).ToList();
        }

        public Language GetById(int id)
        {
            return _context.Languages.Include(x => x.OriginalLanguageOfMovies).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Language> GetDefault(Expression<Func<Language, bool>> exp)
        {
            return _context.Languages.Include(x => x.OriginalLanguageOfMovies).Where(exp).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(Language entity)
        {
            _context.Languages.Update(entity);
            return Save() > 0;
        }
}

using Microsoft.EntityFrameworkCore;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using System.Linq.Expressions;

namespace MovieStore.Repository.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieDbContext _context;
        public MovieRepository(IMovieDbContext context)
        {
            _context = context;
        }

        public bool Add(Movie entity)
        {
            _context.Movies.Add(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            _context.Movies.Remove(GetById(id));
            return Save() > 0;
        }

        public ICollection<Movie> GetAll()
        {
            var movies = _context.Movies.Include(x=>x.Director).Include(x=>x.Category).Include(x=>x.Starrings).Include(x=>x.Language).ToList();
            return movies;
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault();
        }

        public ICollection<Movie> GetDefault(Expression<Func<Movie, bool>> exp)
        {
            return _context.Movies.Where(exp).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(Movie entity)
        {
            _context.Movies.Update(entity);
            return Save() > 0;
        }
    }
}

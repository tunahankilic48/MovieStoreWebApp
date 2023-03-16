using Microsoft.EntityFrameworkCore;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using System.Linq.Expressions;

namespace MovieStore.Repository.Concrete
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly IMovieDbContext _context;
        public DirectorRepository(IMovieDbContext context)
        {
            _context = context;
        }
        public bool Add(Director entity)
        {
            _context.Directors.Add(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            _context.Directors.Remove(GetById(id));
            return Save() > 0;
        }

        public ICollection<Director> GetAll()
        {
            return _context.Directors.ToList();
        }

        public Director GetById(int id)
        {
            return _context.Directors.Include(x => x.DirectedMovies).FirstOrDefault(x => x.Id == id);

        }

        public ICollection<Director> GetDefault(Expression<Func<Director, bool>> exp)
        {
            return _context.Directors.Include(x=>x.DirectedMovies).Where(exp).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(Director entity)
        {
            _context.Directors.Update(entity);
            return Save() > 0;
        }
    }
}

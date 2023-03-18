using Microsoft.EntityFrameworkCore;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using System.Linq.Expressions;

namespace MovieStore.Repository.Concrete
{
    public class StarringRepository : IStarringRepository
    {
        private readonly IMovieDbContext _context;
        public StarringRepository(IMovieDbContext context)
        {
            _context = context;
        }
        public bool Add(Starring entity)
        {
            _context.Starrings.Add(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            _context.Starrings.Remove(GetById(id));
            return Save() > 0;
        }

        public ICollection<Starring> GetAll()
        {
            return _context.Starrings.Include(x=>x.PerformedMovies).ToList();
        }

        public Starring GetById(int id)
        {
            return _context.Starrings.Include(x=>x.PerformedMovies).FirstOrDefault(x => x.Id == id);

        }

        public ICollection<Starring> GetDefault(Expression<Func<Starring, bool>> exp)
        {
            return _context.Starrings.Include(x => x.PerformedMovies).Where(exp).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(Starring entity)
        {
            _context.Starrings.Update(entity);
            return Save() > 0;
        }
    }
}

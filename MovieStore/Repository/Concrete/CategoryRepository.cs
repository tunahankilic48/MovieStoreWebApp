using Microsoft.EntityFrameworkCore;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using System.Linq.Expressions;

namespace MovieStore.Repository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMovieDbContext _context;
        public CategoryRepository(IMovieDbContext context)
        {
            _context = context;
        }
        public bool Add(Category entity)
        {
            _context.Categories.Add(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            _context.Categories.Remove(GetById(id));
            return Save() > 0;
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories.Include(x=>x.Movies).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Include(x => x.Movies).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Category> GetDefault(Expression<Func<Category, bool>> exp)
        {
            return _context.Categories.Include(x => x.Movies).Where(exp).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(Category entity)
        {
            _context.Categories.Update(entity);
            return Save() > 0;
        }
    }
}

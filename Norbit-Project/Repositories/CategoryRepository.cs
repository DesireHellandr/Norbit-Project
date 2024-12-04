using Norbit_Project.Data;
using Norbit_Project.Models;

namespace Norbit_Project.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.categories.Find(id);
        }

        public void Add(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.categories.Find(id);
            if (category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}

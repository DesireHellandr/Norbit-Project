using Norbit_Project.Data;
using Norbit_Project.Models;
using System.ComponentModel;
using System.Numerics;
using Component = Norbit_Project.Models.Component;

namespace Norbit_Project.Repositories
{
    public class ComponentRepository
    {
        private readonly ApplicationDbContext _context;

        public ComponentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Component> GetAll()
        {
            return _context.components.ToList();
        }

        public Component GetById(int id)
        {
            return _context.components.Find(id);
        }

        public void Add(Component component)
        {
            _context.components.Add(component);
            _context.SaveChanges();
        }

        public void Update(Component component)
        {
            _context.components.Update(component);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var component = _context.components.Find(id);
            if (component != null)
            {
                _context.components.Remove(component);
                _context.SaveChanges();
            }
        }
    }
}


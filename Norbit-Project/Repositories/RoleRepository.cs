using Norbit_Project.Data;
using Norbit_Project.Models;
using System.Data;
using System.Numerics;

namespace Norbit_Project.Repositories
{
    public class RoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.roles.ToList();
        }

        public Role GetById(int id)
        {
            return _context.roles.Find(id);
        }

        public void Add(Role role)
        {
            _context.roles.Add(role);
            _context.SaveChanges();
        }

        public void Update(Role role)
        {
            _context.roles.Update(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _context.roles.Find(id);
            if (role != null)
            {
                _context.roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}


using Norbit_Project.Data;
using Norbit_Project.Models;
using System.Numerics;

namespace Norbit_Project.Repositories
{
    public class BodyRepository
    {
        private readonly ApplicationDbContext _context;

        public BodyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Body> GetAll()
        {
            return _context.bodies.ToList();
        }

        public Body GetById(int id)
        {
            return _context.bodies.Find(id);
        }

        public void Add(Body body)
        {
            _context.bodies.Add(body);
            _context.SaveChanges();
        }

        public void Update(Body body)
        {
            _context.bodies.Update(body);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var body = _context.bodies.Find(id);
            if (body != null)
            {
                _context.bodies.Remove(body);
                _context.SaveChanges();
            }
        }
    }
}


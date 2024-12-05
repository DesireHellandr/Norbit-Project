using Norbit_Project.Data;
using Norbit_Project.Models;
using System.Numerics;

namespace Norbit_Project.Repositories
{
    public class PlaceRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Place> GetAll()
        {
            return _context.places.ToList();
        }

        public Place GetById(int id)
        {
            return _context.places.Find(id);
        }

        public void Add(Place place)
        {
            _context.places.Add(place);
            _context.SaveChanges();
        }

        public void Update(Place place)
        {
            _context.places.Update(place);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var place = _context.places.Find(id);
            if (place != null)
            {
                _context.places.Remove(place);
                _context.SaveChanges();
            }
        }
    }
}


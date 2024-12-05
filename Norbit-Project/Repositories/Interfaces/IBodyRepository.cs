using Norbit_Project.Models;

namespace Norbit_Project.Repositories.Interfaces
{
    public interface IBodyRepository
    {
        IEnumerable<Body> GetAllBodies();
        Body GetBodyById(int id);
        void AddBody(Body body);
        void UpdateBody(Body body);
        void DeleteBody(int id);
    }
}

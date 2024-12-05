using Norbit_Project.Models;

namespace Norbit_Project.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAllPlaces();
        Place GetPlaceById(int id);
        void AddPlace(Place place);
        void UpdatePlace(Place place);
        void DeletePlace(int id);
    }
}

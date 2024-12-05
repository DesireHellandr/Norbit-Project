using Norbit_Project.Models;

namespace Norbit_Project.Repositories.Interfaces
{
    public interface IComponentRepository
    {
        IEnumerable<Component> GetAllComponents();
        Component GetComponentById(int id);
        void AddComponent(Component component);
        void UpdateComponent(Component component);
        void DeleteComponent(int id);
    }
}

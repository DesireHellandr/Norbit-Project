using Norbit_Project.Models;

namespace Norbit_Project.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void AddRole(Role role);
        void UpdateRolee(Role role);
        void DeleteRole(int id);
    }
}

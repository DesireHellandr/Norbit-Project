using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;

namespace Norbit_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _repository;

        public RoleController(RoleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] // Для получения всех ролей
        public ActionResult<IEnumerable<Role>> GetAll()
        {
            var roles = _repository.GetAll();
            return Ok(roles);
        }

        [HttpGet("getById")] // Для получения роли по ID
        public ActionResult<Role> GetById([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            var role = _repository.GetById(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost] // Для добавления новой роли
        public ActionResult<Role> Create([FromBody] Role role)
        {
            if (role == null)
                return BadRequest("Role cannot be null.");

            _repository.Add(role);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")] // Для обновления роли
        public ActionResult Update(int id, [FromBody] Role role)
        {
            if (role == null || id != role.Id)
                return BadRequest("Invalid role data.");

            _repository.Update(role);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления роли
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            _repository.Delete(id);
            return NoContent();
        }
    }
}

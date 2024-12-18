using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;
using Component = Norbit_Project.Models.Component;

namespace Norbit_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly ComponentRepository _repository;

        public ComponentController(ComponentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("getAll")] // Для получения всех деталей
        public ActionResult<IEnumerable<Component>> GetAll()
        {
            var components = _repository.GetAll();
            return Ok(components);
        }

        [HttpPost("getById")] // Для получения детали по ID
        public ActionResult<Component> GetById([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            var component = _repository.GetById(id);
            if (component == null)
                return NotFound();

            return Ok(component);
        }

        [HttpPost] // Для добавления новой детали
        public ActionResult<Component> Create([FromBody] Component component)
        {
            if (component == null)
                return BadRequest("Component cannot be null.");

            _repository.Add(component);
            return CreatedAtAction(nameof(GetById), new { id = component.Id }, component);
        }

        [HttpPut("{id}")] // Для обновления детали
        public ActionResult Update(int id, [FromBody] Component component)
        {
            if (component == null || id != component.Id)
                return BadRequest("Invalid component data.");

            _repository.Update(component);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления детали
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            _repository.Delete(id);
            return NoContent();
        }
    }
}

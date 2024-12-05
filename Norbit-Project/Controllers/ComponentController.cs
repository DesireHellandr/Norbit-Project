using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;
using Component = Norbit_Project.Models.Component;

namespace Norbit_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly ComponentRepository _repository;

        public ComponentController(ComponentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] // Для получения всех деталей
        public ActionResult GetAll()
        {
            var components = _repository.GetAll();
            return Ok(components);
        }

        [HttpGet("{id}")] // Для получения детали по ID
        public ActionResult GetById(int id)
        {
            var component = _repository.GetById(id);
            if (component == null)
                return NotFound();

            return Ok(component);
        }

        [HttpPost] // Для добавления новой детали
        public ActionResult Create(Component component)
        {
            _repository.Add(component);
            return CreatedAtAction(nameof(GetById), new { id = component.Id }, component);
        }

        [HttpPut("{id}")] // Для обновления места хранения
        public ActionResult Update(int id, Component component)
        {
            if (id != component.Id)
                return BadRequest();

            _repository.Update(component);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления детали
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}

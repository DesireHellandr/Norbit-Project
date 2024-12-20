using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;

namespace Norbit_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {
        private readonly BodyRepository _repository;

        public BodyController(BodyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")] // Получение всех корпусов
        public ActionResult<IEnumerable<Body>> GetAll()
        {
            var bodies = _repository.GetAll();
            return Ok(bodies);
        }

        [HttpGet("getById")] // Получение корпуса по ID
        public ActionResult<Body> GetById([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var body = _repository.GetById(id);
            if (body == null)
                return NotFound();

            return Ok(body);
        }

        [HttpPost] // Добавление нового корпуса
        public ActionResult<Body> Create([FromBody] Body body)
        {
            if (body == null)
                return BadRequest("Body cannot be null");

            _repository.Add(body);
            return CreatedAtAction(nameof(GetById), new { id = body.Id }, body);
        }

        [HttpPut("{id}")] // Обновление корпуса
        public ActionResult Update(int id, [FromBody] Body body)
        {
            if (body == null || id != body.Id)
                return BadRequest("Invalid body data");

            _repository.Update(body);
            return NoContent();
        }

        [HttpDelete("{id}")] // Удаление корпуса
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            _repository.Delete(id);
            return NoContent();
        }
    }
}

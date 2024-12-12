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

        [HttpGet] // Для получения всех корпусов
        public ActionResult GetAll()
        {
            var bodies = _repository.GetAll();
            return Ok(bodies);
        }

        [HttpGet("{id}")] // Для получения корпуса по ID
        public ActionResult GetById(int id)
        {
            var body = _repository.GetById(id);
            if (body == null)
                return NotFound();

            return Ok(body);
        }

        [HttpPost] // Для добавления нового корпуса
        public ActionResult Create(Body body)
        {
            _repository.Add(body);
            return CreatedAtAction(nameof(GetById), new { id = body.Id }, body);
        }

        [HttpPut("{id}")] // Для обновления корпуса
        public ActionResult Update(int id, Body body)
        {
            if (id != body.Id)
                return BadRequest();

            _repository.Update(body);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления места хранения
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}

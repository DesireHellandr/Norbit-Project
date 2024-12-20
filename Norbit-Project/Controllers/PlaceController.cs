using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;

namespace Norbit_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly PlaceRepository _repository;

        public PlaceController(PlaceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")] // Для получения всех мест хранения
        public ActionResult<IEnumerable<Place>> GetAll()
        {
            var places = _repository.GetAll();
            return Ok(places);
        }

        [HttpGet("getById")] // Для получения места хранения по ID
        public ActionResult<Place> GetById([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            var place = _repository.GetById(id);
            if (place == null)
                return NotFound();

            return Ok(place);
        }

        [HttpPost] // Для добавления нового места хранения
        public ActionResult<Place> Create([FromBody] Place place)
        {
            if (place == null)
                return BadRequest("Place cannot be null.");

            _repository.Add(place);
            return CreatedAtAction(nameof(GetById), new { id = place.Id }, place);
        }

        [HttpPut("{id}")] // Для обновления места хранения
        public ActionResult Update(int id, [FromBody] Place place)
        {
            if (place == null || id != place.Id)
                return BadRequest("Invalid place data.");

            _repository.Update(place);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления места хранения
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            _repository.Delete(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;

namespace Norbit_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly PlaceRepository _repository;

        public PlaceController(PlaceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] // Для получения всех мест хранения
        public ActionResult GetAll()
        {
            var places = _repository.GetAll();
            return Ok(places);
        }

        [HttpGet("{id}")] // Для получения места хранения по ID
        public ActionResult GetById(int id)
        {
            var place = _repository.GetById(id);
            if (place == null)
                return NotFound();

            return Ok(place);
        }

        [HttpPost] // Для добавления новой места хранения
        public ActionResult Create(Place place)
        {
            _repository.Add(place);
            return CreatedAtAction(nameof(GetById), new { id = place.Id }, place);
        }

        [HttpPut("{id}")] // Для обновления места хранения
        public ActionResult Update(int id, Place place)
        {
            if (id != place.Id)
                return BadRequest();

            _repository.Update(place);
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

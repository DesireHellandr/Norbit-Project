using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;



namespace Norbit_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] // Для получения всех категорий
        public ActionResult GetAll()
        {
            var categories = _repository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")] // Для получения категории по ID
        public ActionResult GetById(int id)
        {
            var category = _repository.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost] // Для добавления новой категории
        public ActionResult Create(Category category)
        {
            _repository.Add(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")] // Для обновления категории
        public ActionResult Update(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest();

            _repository.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления категории
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}

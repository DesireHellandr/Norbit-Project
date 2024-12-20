using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;
using Norbit_Project.Repositories;



namespace Norbit_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")] // Для получения всех категорий
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var categories = _repository.GetAll();
            return Ok(categories);
        }

        [HttpGet("getById")] // Для получения категории по ID
        public ActionResult<Category> GetById([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            var category = _repository.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost] // Для добавления новой категории
        public ActionResult<Category> Create([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Category cannot be null.");

            _repository.Add(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")] // Для обновления категории
        public ActionResult Update(int id, [FromBody] Category category)
        {
            if (category == null || id != category.Id)
                return BadRequest("Invalid category data.");

            _repository.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")] // Для удаления категории
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided.");

            _repository.Delete(id);
            return NoContent();
        }
    }
}

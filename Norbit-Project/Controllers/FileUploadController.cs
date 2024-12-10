using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Models;

namespace Norbit_Project.Controllers
{
    [Route("[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileUpload model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var filePath = Path.Combine(_environment.ContentRootPath, "uploads", model.File.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }

            return Ok(new { Filename = model.File.FileName });
        }
        [HttpGet("image/{filename}")]
        public IActionResult GetImage(string filename)
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "uploads", filename);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "image/jpeg");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Norbit_Project.Data;
using Norbit_Project.Models;
using Norbit_Project.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Norbit_Project.Controllers
{
    [ApiController]
    public class HtmlPageController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public HtmlPageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("main")]
        public async Task<IActionResult> GetMainHtml()
        {
            var filePath = Path.Combine(_environment.WebRootPath, "main.html");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            return File(await System.IO.File.ReadAllBytesAsync(filePath), "text/html");
        }
    }
}

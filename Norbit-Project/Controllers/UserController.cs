using Microsoft.AspNetCore.Mvc;
using Norbit_Project.Data;
using Norbit_Project.Models;
using Norbit_Project.Repositories;

namespace Norbit_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            user.Password = HashPassword(user.Password); // Метод для хеширования пароля
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.Password)) // Проверка пароля
            {
                return Unauthorized();
            }
            var token = GenerateJwtToken(user); // Метод для генерации токена
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        private string GenerateJwtToken(User user)
        {
            // Реализация генерации токена
        }

        private string HashPassword(string password)
        {
            // Реализация хеширования
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Реализация проверки пароля
        }
    }

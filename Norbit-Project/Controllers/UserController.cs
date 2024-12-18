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
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("User data is invalid.");
            }

            user.Password = HashPassword(user.Password); // Метод для хеширования пароля
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Email and password are required.");
            }

            var user = await _userRepository.GetUserByEmailAsync(loginModel.Email);
            if (user == null || !VerifyPassword(loginModel.Password, user.Password)) // Проверка пароля
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(user); // Метод для генерации токена
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", user.RoleId.ToString())
            };

            var key = AuthOptions.GetSymmetricSecurityKey(); // Получаем симметричный ключ
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            // Реализация хеширования
            using (var hmac = new HMACSHA512())
            {
                var salt = hmac.Key;
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Реализация проверки пароля
            var parts = hashedPassword.Split(".");
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = Convert.FromBase64String(parts[1]);

            using (var hmac = new HMACSHA512(salt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hash.Length; i++)
                    if (hash[i] != storedHash[i]) return false;
            }

            return true;
        }
    }
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

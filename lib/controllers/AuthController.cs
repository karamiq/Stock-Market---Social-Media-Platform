using dtos.auth;
using helpers;
using interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using models;
using System.Security.Cryptography;
using System.Text;

namespace controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _jwtService = new JwtService(config);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var existing = await _userRepository.GetByEmailAsync(dto.Email);
            if (existing != null) return BadRequest("Email already in use");
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };
            await _userRepository.CreateAsync(user);
            var token = _jwtService.GenerateToken(user);
            return Ok(new AuthResultDto { Token = token, ExpiresAt = DateTime.UtcNow.AddMinutes(60) });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized();
            var token = _jwtService.GenerateToken(user);
            return Ok(new AuthResultDto { Token = token, ExpiresAt = DateTime.UtcNow.AddMinutes(60) });
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
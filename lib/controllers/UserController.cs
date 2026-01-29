using dtos.user;
using interfaces;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using models;

namespace controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users.Select(u => u.ToUserDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var user = dto.ToUser();
            // TODO: Hash password before saving
            var created = await _userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToUserDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            user.Username = dto.Username ?? user.Username;
            user.Email = dto.Email ?? user.Email;
            if (!string.IsNullOrEmpty(dto.Password))
            {
                // TODO: Hash password before saving
                user.PasswordHash = dto.Password;
            }
            var updated = await _userRepository.UpdateAsync(id, user);
            return Ok(updated?.ToUserDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
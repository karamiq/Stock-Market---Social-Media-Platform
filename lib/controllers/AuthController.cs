using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.auth;
using api.Models;
using dtos.auth;
using helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models;
using api.Data;
using BCrypt.Net;

namespace api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IJwtService _tokenService;

        public AuthController(ApplicationDBContext context, IJwtService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

            if (user == null) return Unauthorized("Invalid email!");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return Unauthorized("Email not found and/or password incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.Username,
                    Email = user.Email,
                    Token = _tokenService.GenerateToken(user)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (await _context.Users.AnyAsync(x => x.Email == registerDto.Email.ToLower()))
                    return BadRequest("Email is already taken");

                var user = new User
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email.ToLower(),
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(
                    new NewUserDto
                    {
                        UserName = user.Username,
                        Email = user.Email,
                        Token = _tokenService.GenerateToken(user)
                    }
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
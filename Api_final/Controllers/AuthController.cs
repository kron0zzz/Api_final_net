
using Api_final.DTOs;
using Api_final.Interfaces;
using Api_final.Models;
using Api_final.Services;
using Api_final.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _users;
        private readonly PasswordService _passwords;
        private readonly JwtService _jwt;

        public AuthController(IUserRepository users, PasswordService passwords, JwtService jwt)
        {
            _users = users;
            _passwords = passwords;
            _jwt = jwt;
        }

        // REGISTRO
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var exists = await _users.GetByUserNameAsync(dto.UserName);
            if (exists != null)
                return BadRequest("El usuario ya existe");

            var user = new Users
            {
                UserName = dto.UserName,
                PasswordHash = _passwords.Hash(dto.Password),
                Role = dto.Role
            };

            await _users.RegisterAsync(user);

            return Ok("Usuario registrado correctamente");
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var user = await _users.GetByUserNameAsync(dto.UserName);
            if (user == null)
                return Unauthorized("Usuario no encontrado");

            if (!_passwords.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Contraseña incorrecta");

            var token = _jwt.Generate(user);

            return Ok(new { token });
        }
    }

}
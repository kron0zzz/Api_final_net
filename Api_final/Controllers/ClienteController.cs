using Api_final.Data;
using Api_final.Interfaces;
using Api_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_final.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Api_final.Controllers
{
    //[Authorize]        descomentar para activar el token
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cl = await _repository.GetByIdAsync(id);
            if (cl == null) return NotFound();
            return Ok(cl);
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto dto)
        {
            var newCl = new Clientes
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Telefono = dto.Telefono
               
            };


            var created = await _repository.AddAsync(newCl);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto dto)
        {
            var update = new Clientes
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Telefono = dto.Telefono
            };


            var updated = await _repository.UpdateAsync(id, update);
            if (updated == null) return NotFound();
            return Ok(updated);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }



    }
}









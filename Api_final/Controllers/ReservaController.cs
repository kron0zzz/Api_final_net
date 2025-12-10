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
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _repository;
        public ReservaController(IReservaRepository repository)
        {
            _repository = repository;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var re = await _repository.GetByIdAsync(id);
            if (re == null) return NotFound();
            return Ok(re);
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservaDto dto)
        {
            var newRe = new Reservas
            {
                IdServicio = dto.IdServicio,
                IdCliente = dto.IdCliente,
                Estado = dto.Estado
            };


            var created = await _repository.AddAsync(newRe);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReservaDto dto)
        {
            var update = new Reservas
            {
                IdServicio = dto.IdServicio,
                IdCliente = dto.IdCliente,
                Estado = dto.Estado
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



   





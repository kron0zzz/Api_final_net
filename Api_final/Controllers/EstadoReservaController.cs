using Api_final.Data;
using Api_final.Interfaces;
using Api_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_final.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Api_final.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoReservaController : ControllerBase
    {
        private readonly IEstadoReservaRepository _repository;
        public EstadoReservaController(IEstadoReservaRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoReservaDto dto)
        {
            var newSe = new EstadoReserva
            {
                Descripcion = dto.Descripcion

            };


            var created = await _repository.AddAsync(newSe);
            return Created("", created);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoReservaDto dto)
        {
            var update = new EstadoReserva
            {
                Descripcion = dto.Descripcion

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









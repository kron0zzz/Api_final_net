using Microsoft.AspNetCore.Mvc;
using Api_final.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_final.Controllers
{
    [ApiController]
    [Route("api / [controller] ")]
    public class ReservaController : ControllerBase
    {
        private readonly ApiContext _context;
        public ReservaController(ApiContext context)
        {
            _context = context;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservas = await _context.Reservas.ToListAsync();
            return Ok(reservas);
        }
    }
}



   





using Microsoft.AspNetCore.Mvc;
using HotelBackend.Models;
using HotelBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace HotelBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;
        private readonly HotelContext _context;

        public ReservaController(IReservaService service,HotelContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reserva reserva)
        {
            var exito = await _service.CrearReserva(reserva);
            
            if (!exito)
            {
                return BadRequest(new { message = "La habitación no está disponible en esas fechas." });
            }

            return Ok(new { message = "Reserva creada con éxito" });
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservas = await _context.Reservas
                .Include(r => r.IdHuespedNavigation)
                .Include(r => r.IdHabitacionNavigation)
                    .ThenInclude(h => h.IdTipoNavigation) 
                .ToListAsync();

        
            return Ok(reservas);
        }
        [HttpPut("{id}/checkin")]
        public async Task<IActionResult> RegistrarCheckin(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();

            reserva.FechaHoraCheckin = DateTime.Now;
            reserva.Estado = "Hospedado";
            
            await _context.SaveChangesAsync();
            return Ok(new { message = "Check-in realizado con éxito", hora = reserva.FechaHoraCheckin });
        }

        [HttpPut("{id}/checkout")]
        public async Task<IActionResult> RegistrarCheckout(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();

            reserva.FechaHoraCheckout = DateTime.Now;
            reserva.Estado = "Finalizada";
            
            await _context.SaveChangesAsync();
            return Ok(new { message = "Check-out realizado con éxito", hora = reserva.FechaHoraCheckout });
        }
        
    }
}
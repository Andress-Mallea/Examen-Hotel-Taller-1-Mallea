using Microsoft.AspNetCore.Mvc;
using HotelBackend.Interfaces;
using HotelBackend.Patterns;
namespace HotelBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionService _service;

        public HabitacionController(IHabitacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var habitaciones = await _service.ObtenerTodas();
            return Ok(habitaciones);
        }
        [HttpGet("variacion/{tipo}")]
        public IActionResult GetInfoVariacion(string tipo)
        {
            try
            {
                var info = VariacionHabitacionFactory.GetVariacion(tipo);
                return Ok(info);
            }
            catch (ArgumentException)
            {
                return BadRequest(new { message = "Tipo de habitación no válido" });
            }
        }
    }
}
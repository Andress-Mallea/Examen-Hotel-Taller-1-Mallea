using Microsoft.AspNetCore.Mvc;
using HotelBackend.Models;
using HotelBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace HotelBackend.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class HuespedController : ControllerBase
{
    private readonly IHuespedService _service;
    private readonly HotelContext _context; 

   
    public HuespedController(IHuespedService service, HotelContext context)
    {
        _service = service;
        _context = context; 
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Huespede huesped) 
    {
        var resultado = await _service.RegistrarHuesped(huesped);
        if (!resultado) return BadRequest(new { message = "El documento ya existe." });
        return Ok(new { message = "Registrado con éxito" });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var huesped = await _context.Huespedes.FindAsync(id);

        if (huesped == null)
        {
  
            return NotFound(new { message = "El huésped solicitado no existe en el sistema." });
        }

        return Ok(huesped);
    }
    [HttpGet]
        public async Task<IActionResult> Get()
        {
            var huespedes = await _context.Huespedes.ToListAsync();
            
            return Ok(huespedes);
        }
}
}

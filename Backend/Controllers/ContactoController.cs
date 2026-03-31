using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBackend.Models;

namespace HotelBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactoController : ControllerBase
{
    private readonly HotelContext _context;

    public ContactoController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var contactos = await _context.ContactosServicios.ToListAsync();
        
        if (contactos == null || contactos.Count == 0)
        {
            return NotFound(new { message = "No hay contactos disponibles." });
        }

        return Ok(contactos);
    }
}
using HotelBackend.Models;
using HotelBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBackend.Services
{
    public class HuespedService : IHuespedService
    {
        private readonly HotelContext _context;

        public HuespedService(HotelContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarHuesped(Huespede nuevoHuesped)
        {
    
            var existe = await _context.Huespedes
                .AnyAsync(h => h.DocumentoIdentidad == nuevoHuesped.DocumentoIdentidad);
            
            if (existe) return false;

            _context.Huespedes.Add(nuevoHuesped);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
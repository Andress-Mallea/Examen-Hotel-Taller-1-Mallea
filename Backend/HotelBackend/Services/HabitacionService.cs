using HotelBackend.Models;
using HotelBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBackend.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly HotelContext _context;

        public HabitacionService(HotelContext context)
        {
            _context = context;
        }
        public void ValidarPrecioBase(decimal precio)
        {
            if (precio < 0) throw new ArgumentException("Invalido");
        }
        public async Task<IEnumerable<Habitacione>> ObtenerTodas()
        {
        
            return await _context.Habitaciones
                .Include(h => h.IdTipoNavigation) 
                .ToListAsync();
        }
    }
}
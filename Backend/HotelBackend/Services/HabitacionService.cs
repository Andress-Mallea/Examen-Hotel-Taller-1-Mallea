using HotelBackend.Models;
using HotelBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBackend.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly HotelContext _context;
        private const decimal PRECIO_MINIMO_PERMITIDO = 0.0m;
        private const int CAPACIDAD_MAXIMA = 6;
        public HabitacionService(HotelContext context)
        {
            _context = context;
        }
        public void ValidarPrecioBase(decimal precio)
        {
            if (precio < PRECIO_MINIMO_PERMITIDO)
            {
                throw new ArgumentException($"El precio por noche no puede ser menor a {PRECIO_MINIMO_PERMITIDO}.");
            }
        }
        public bool EsCapacidadPermitida(int capacidad)
        {
            return capacidad > 0 && capacidad <= CAPACIDAD_MAXIMA;
        }
        public async Task<IEnumerable<Habitacione>> ObtenerTodas()
        {
        
            return await _context.Habitaciones
                .Include(h => h.IdTipoNavigation) 
                .ToListAsync();
        }
    }
}
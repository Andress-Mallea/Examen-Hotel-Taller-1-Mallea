using HotelBackend.Models;
using HotelBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBackend.Services
{
    public class ReservaService : IReservaService
    {
        private readonly HotelContext _context;

        public ReservaService(HotelContext context)
        {
            _context = context;
        }

        public async Task<bool> VerificarDisponibilidad(int idHabitacion, DateOnly fechaInicio, DateOnly fechaFin)
        {

            bool ocupada = await _context.Reservas.AnyAsync(r => 
                r.IdHabitacion == idHabitacion &&
                ((fechaInicio >= r.FechaIngreso && fechaInicio < r.FechaSalida) ||
                 (fechaFin > r.FechaIngreso && fechaFin <= r.FechaSalida) ||
                 (fechaInicio <= r.FechaIngreso && fechaFin >= r.FechaSalida)));

            return !ocupada;
        }

        public async Task<bool> CrearReserva(Reserva nuevaReserva)
        {
          
            if (nuevaReserva.IdHabitacion == null) return false;

            var disponible = await VerificarDisponibilidad(
                nuevaReserva.IdHabitacion.Value, 
                nuevaReserva.FechaIngreso, 
                nuevaReserva.FechaSalida);

            if (!disponible) return false;

            _context.Reservas.Add(nuevaReserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
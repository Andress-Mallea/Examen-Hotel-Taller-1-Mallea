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
        public void ValidarFechas(DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new ArgumentException("Error");
            }
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
            // ANTES (Con múltiples returns):
            /*
            if (nuevaReserva.IdHabitacion == null) return false;
            var disponible = await VerificarDisponibilidad(...);
            if (!disponible) return false;
            _context.Reservas.Add(nuevaReserva);
            await _context.SaveChangesAsync();
            return true;
            */

            // DESPUÉS (Un solo punto de salida - Single Return):
            bool reservaCreadaExitosamente = false;

            if (nuevaReserva.IdHabitacion != null)
            {
                bool disponible = await VerificarDisponibilidad(
                    nuevaReserva.IdHabitacion.Value, 
                    nuevaReserva.FechaIngreso, 
                    nuevaReserva.FechaSalida);

                if (disponible)
                {
                    _context.Reservas.Add(nuevaReserva);
                    await _context.SaveChangesAsync();
                    reservaCreadaExitosamente = true;
                }
            }
            var a= 122;
            return reservaCreadaExitosamente;
        } 
       
    }
}
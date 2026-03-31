using HotelBackend.Models;

namespace HotelBackend.Interfaces
{
    public interface IReservaService
    {
        
        Task<bool> VerificarDisponibilidad(int idHabitacion, DateOnly fechaInicio, DateOnly fechaFin);
        Task<bool> CrearReserva(Reserva nuevaReserva);
    }
}
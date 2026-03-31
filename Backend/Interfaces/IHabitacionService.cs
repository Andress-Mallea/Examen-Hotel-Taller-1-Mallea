using HotelBackend.Models;

namespace HotelBackend.Interfaces
{
    public interface IHabitacionService
    {
        Task<IEnumerable<Habitacione>> ObtenerTodas();
    }
}
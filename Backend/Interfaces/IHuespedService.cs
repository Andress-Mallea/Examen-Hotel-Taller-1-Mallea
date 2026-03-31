using HotelBackend.Models;

namespace HotelBackend.Interfaces
{
    public interface IHuespedService
    {

        Task<bool> RegistrarHuesped(Huespede nuevoHuesped);
    }
}
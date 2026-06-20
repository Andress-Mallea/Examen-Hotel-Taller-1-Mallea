using Xunit;
using HotelBackend.Patterns;
using HotelBackend.Services;

namespace HotelBackend.Tests;

public class ReservationServiceTests
{
    [Fact]
    public void ValidarFechas_AceptaFechasCorrectas()
    {
        var srv = new ReservaService(null);
        srv.ValidarFechas(new DateTime(2026, 10, 01), new DateTime(2026, 10, 05));
    }
    [Fact]
    public void ValidarFechas_FallaCheckOutAntesDeCheckIn()
    {
        var srv = new ReservaService(null);
        var entrada = new DateTime(2026, 06, 10);
        var salida = new DateTime(2026, 06, 05); 
        
        Action act = () => srv.ValidarFechas(entrada, salida);
        Assert.Throws<ArgumentException>(act);
    }
}
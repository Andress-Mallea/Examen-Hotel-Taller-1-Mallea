using Xunit;
using HotelBackend.Patterns;
using HotelBackend.Services;

namespace HotelBackend.Tests;

public class ReservationServiceTests
{
    [Fact]
    public void VariacionHabitacionFactory_GetVariacion_ConTipoInvalido_DebeRetornarThrowException()
    {
        // Arrange
        string tipoInvalido = "tipo que no existe";
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => VariacionHabitacionFactory.GetVariacion(tipoInvalido));
    }

    [Fact]
    public void VariacionHabitacionFactory_GetVariacion_ConTipoSuite_DebeRetornarSuite()
    {
        // Arrange
        string tipo = "suite";
        
        // Act
        var resultado = VariacionHabitacionFactory.GetVariacion(tipo);
        
        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Suite", resultado.Nombre);
    }
    [Fact]
    public void ValidarFechas_CheckOutMenorACheckIn_DebeLanzarExcepcion()
    {
        var service = new ReservaService(null);
        var checkIn = new DateTime(2026, 06, 10);
        var checkOut = new DateTime(2026, 06, 05); 
        Action act = () => service.ValidarFechas(checkIn, checkOut);
        Assert.Throws<ArgumentException>(act);
    }
}
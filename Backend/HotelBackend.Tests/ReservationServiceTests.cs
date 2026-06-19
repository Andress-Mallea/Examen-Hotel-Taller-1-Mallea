using Xunit;
using HotelBackend.Patterns;

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
}
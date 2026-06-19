using Xunit;
using HotelBackend.Patterns;

namespace HotelBackend.Tests;

public class VariacionHabitacionFactoryTests
{
    [Fact]
    public void GetVariacion_TipoSimple_DebeRetornarDatosCorrectos()
    {
        // Arrange
        string tipo = "simple";

        // Act
        var resultado = VariacionHabitacionFactory.GetVariacion(tipo);

        // Assert
        Assert.Equal(1, resultado.Capacidad);
        Assert.Equal(150m, resultado.PrecioBase);
        Assert.Equal("Simple", resultado.Nombre);
    }
    
}
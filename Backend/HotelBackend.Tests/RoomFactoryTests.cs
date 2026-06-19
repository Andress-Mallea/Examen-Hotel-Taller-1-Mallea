using Xunit;
using HotelBackend.Patterns;

namespace HotelBackend.Tests;

public class RoomFactoryTests
{
    [Fact]
    public void GetVariacion_TipoDobleMatrimonial_DebeRetornarPrecioCorrect()
    {
        // Arrange
        string tipo = "doble matrimonial";
        
        // Act
        var resultado = VariacionHabitacionFactory.GetVariacion(tipo);
        
        // Assert
        Assert.Equal(2, resultado.Capacidad);
        Assert.Equal(280m, resultado.PrecioBase);
        Assert.Equal("Doble Matrimonial", resultado.Nombre);
    }

    [Fact]
    public void GetVariacion_TipoDobleConCamasIndividuales_DebeRetornarDatosCorrectos()
    {
        // Arrange
        string tipo = "doble con camas individuales";
        
        // Act
        var resultado = VariacionHabitacionFactory.GetVariacion(tipo);
        
        // Assert
        Assert.Equal(2, resultado.Capacidad);
        Assert.Equal(250m, resultado.PrecioBase);
        Assert.Contains("camas individuales", resultado.Nombre.ToLower());
    }
}
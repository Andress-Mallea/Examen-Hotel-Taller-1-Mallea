using Xunit;
using HotelBackend.Patterns;

namespace HotelBackend.Tests;

public class HabitacionServiceTests
{
    [Fact]
    public void ValidarPrecioBase_PrecioNegativo_DebeLanzarExcepcion()
    {
        var service = new HabitacionService(); 
        decimal precioInvalido = -50.0m;
        Assert.Throws<ArgumentException>(() => service.ValidarPrecioBase(precioInvalido));
    }
}
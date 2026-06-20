using Xunit;
using HotelBackend.Patterns;
using HotelBackend.Services;

namespace HotelBackend.Tests;

public class HabitacionServiceTests
{
    [Fact]
    public void ValidarPrecioBase_PrecioNegativo_DebeLanzarExcepcion()
    {
        var service = new HabitacionService(null); 
        decimal precioInvalido = -50.0m;
        Action act = () => service.ValidarPrecioBase(precioInvalido);
        Assert.Throws<ArgumentException>(act);
    }
    [Fact]
    public void EsCapacidadPermitida_MayorA6_RetornaFalse()
    {
        var service = new HabitacionService(null);
        bool result = service.EsCapacidadPermitida(7);
        Assert.False(result);
    }
}
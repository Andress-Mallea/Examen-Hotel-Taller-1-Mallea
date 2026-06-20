using Xunit;
using HotelBackend.Patterns;
using HotelBackend.Services;

namespace HotelBackend.Tests;

public class HabitacionServiceTests
{
    [Fact]
    public void ValidarPrecioBase_FallaConPrecioNegativo()
    {
        var srv = new HabitacionService(null); 
        Action act = () => srv.ValidarPrecioBase(-50.0m);
        
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void EsCapacidadPermitida_FallaSiMayorA6()
    {
        var srv = new HabitacionService(null);
        Assert.False(srv.EsCapacidadPermitida(7));
    }
    [Fact]
    public void EsCapacidadPermitida_AceptaCapacidadMenorA6()
    {
        var srv = new HabitacionService(null);
        Assert.True(srv.EsCapacidadPermitida(2));
    }

    [Fact]
    public void ValidarPrecioBase_AceptaPrecioPositivo()
    {
        var srv = new HabitacionService(null); 
        srv.ValidarPrecioBase(150.0m);
    }
}
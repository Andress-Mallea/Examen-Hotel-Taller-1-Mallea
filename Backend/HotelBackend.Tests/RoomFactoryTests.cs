using Xunit;
using HotelBackend.Patterns;

namespace HotelBackend.Tests;

public class RoomFactoryTests
{
    [Fact]
    public void GetVariacion_FallaConTipoInvalido()
    {
        Assert.Throws<ArgumentException>(() => VariacionHabitacionFactory.GetVariacion("inexistente"));
    }

    [Fact]
    public void GetVariacion_RetornaSuite()
    {
        var res = VariacionHabitacionFactory.GetVariacion("suite");
        Assert.NotNull(res);
        Assert.Equal("Suite", res.Nombre);
    }

    [Fact]
    public void GetVariacion_RetornaDobleMatrimonial()
    {
        var res = VariacionHabitacionFactory.GetVariacion("doble matrimonial");
        Assert.Equal(2, res.Capacidad);
        Assert.Equal(280m, res.PrecioBase);
    }

    [Fact]
    public void GetVariacion_RetornaDobleIndividual()
    {
        var res = VariacionHabitacionFactory.GetVariacion("doble con camas individuales");
        Assert.Equal(2, res.Capacidad);
        Assert.Contains("camas individuales", res.Nombre.ToLower());
    }

    [Fact]
    public void GetVariacion_RetornaSimple()
    {
        var res = VariacionHabitacionFactory.GetVariacion("simple");
        Assert.Equal("Simple", res.Nombre);
    }
}
using System;
using Xunit;
using HotelBackend.Patterns;
using HotelBackend.Services;

namespace HotelBackend.Tests
{
    public class UnitTest1
    {
        // ==========================================
        // 1. CUBRIR TODAS LAS RAMAS DEL FACTORY
        // ==========================================
        [Fact]
        public void GetVariacion_TipoSimple_RetornaCorrecto()
        {
            var resultado = VariacionHabitacionFactory.GetVariacion("simple");
            Assert.Equal("Simple", resultado.Nombre);
        }

        [Fact]
        public void GetVariacion_TipoDobleIndividuales_RetornaCorrecto()
        {
            // Usamos el string exacto de tu switch
            var resultado = VariacionHabitacionFactory.GetVariacion("doble con camas individuales");
            Assert.NotNull(resultado);
        }

        [Fact]
        public void GetVariacion_TipoDobleMatrimonial_RetornaCorrecto()
        {
            // Usamos el string exacto de tu switch
            var resultado = VariacionHabitacionFactory.GetVariacion("doble matrimonial");
            Assert.NotNull(resultado);
        }

        [Fact]
        public void GetVariacion_TipoSuite_RetornaCorrecto()
        {
            var resultado = VariacionHabitacionFactory.GetVariacion("suite");
            Assert.NotNull(resultado); 
        }

        [Fact]
        public void GetVariacion_CualquierOtro_LanzaExcepcion()
        {
            // Le decimos a xUnit que ESPERAMOS que el sistema lance una excepción. 
            // Si la lanza, la prueba pasa con éxito.
            Assert.Throws<ArgumentException>(() => VariacionHabitacionFactory.GetVariacion("invalido"));
        }

        // ==========================================
        // 2. CUBRIR TUS MÉTODOS DEL TDD (SIN BASE DE DATOS)
        // ==========================================
        [Fact]
        public void ValidarPrecioBase_PrecioValido_NoFalla()
        {
            // Le pasamos null porque ValidarPrecioBase no usa la base de datos
            var service = new HabitacionService(null); 
            service.ValidarPrecioBase(150.0m);
        }

        [Fact]
        public void ReservaService_ValidarFechas_FechasValidas_NoFalla()
        {
            // Le pasamos null porque ValidarFechas no usa la base de datos
            var service = new ReservaService(null);
            var checkIn = new DateTime(2026, 10, 01);
            var checkOut = new DateTime(2026, 10, 05);
            service.ValidarFechas(checkIn, checkOut);
        }
    }
}
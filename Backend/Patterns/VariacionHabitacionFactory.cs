namespace HotelBackend.Patterns
{
    public class VariacionBase
    {
        public string Nombre { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public decimal PrecioBase { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }

    public static class VariacionHabitacionFactory
    {
        public static VariacionBase GetVariacion(string tipo)
        {
            return tipo.ToLower() switch
            {
                "simple" => new VariacionBase { 
                    Nombre = "Simple", Capacidad = 1, PrecioBase = 150, 
                    Descripcion = "Habitación individual con servicios esenciales." 
                },
                "doble con camas individuales" => new VariacionBase { 
                    Nombre = "Doble con camas individuales", Capacidad = 2, PrecioBase = 250, 
                    Descripcion = "Habitación con dos camas separadas, ideal para acompañantes." 
                },
                "doble matrimonial" => new VariacionBase { 
                    Nombre = "Doble Matrimonial", Capacidad = 2, PrecioBase = 280, 
                    Descripcion = "Habitación con cama King Size, perfecta para parejas." 
                },
                "suite" => new VariacionBase { 
                    Nombre = "Suite", Capacidad = 4, PrecioBase = 500, 
                    Descripcion = "Máximo lujo con sala de estar y jacuzzi privado." 
                },
                _ => throw new ArgumentException("Variación no válida")
            };
        }
    }
}
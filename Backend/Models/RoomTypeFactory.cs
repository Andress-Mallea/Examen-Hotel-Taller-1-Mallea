namespace HotelBackend.Models
{
    public static class RoomTypeFactory
    {
        public static (int Capacidad, string Descripcion, decimal Precio) GetConfiguracionBase(string tipo)
        {
            return tipo.ToLower() switch
            {
                "simple" => (1, "Habitación individual estándar con servicios básicos.", 150.00m),
                "doble con camas individuales" => (2, "Habitación con dos camas separadas, ideal para amigos.", 250.00m),
                "doble matrimonial" => (2, "Habitación con cama King Size, ideal para parejas.", 280.00m),
                "suite" => (4, "Suite de lujo con sala de estar, jacuzzi y vista panorámica.", 500.00m),
                _ => (0, "Desconocido", 0.00m)
            };
        }
    }
}
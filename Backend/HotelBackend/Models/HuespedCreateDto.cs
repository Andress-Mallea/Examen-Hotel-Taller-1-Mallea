namespace HotelBackend.Models
{
    
    public class HuespedCreateDto
    {
        public string Nombre { get; set; } = null!;
        
        public string Apellido { get; set; } = null!;
        
        public string DocumentoIdentidad { get; set; } = null!;
        
        public string? Telefono { get; set; }
        
        public string? Correo { get; set; }
    }
}

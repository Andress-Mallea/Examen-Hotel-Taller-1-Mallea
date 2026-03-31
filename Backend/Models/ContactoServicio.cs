namespace HotelBackend.Models;

public partial class ContactoServicio
{
    public int IdContacto { get; set; }
    public string NombreServicio { get; set; } = null!;
    public string Encargado { get; set; } = null!;
    public string Telefono { get; set; } = null!;
}
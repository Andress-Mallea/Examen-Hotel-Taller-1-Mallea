using System;
using System.Collections.Generic;

namespace HotelBackend.Models;

public partial class Huespede
{
    public int IdHuesped { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string DocumentoIdentidad { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

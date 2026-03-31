using System;
using System.Collections.Generic;

namespace HotelBackend.Models;

public partial class TiposHabitacion
{
    public int IdTipo { get; set; }

    public string Denominacion { get; set; } = null!;

    public int CapacidadMaxima { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}

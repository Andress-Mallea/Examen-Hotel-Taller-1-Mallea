using System;
using System.Collections.Generic;

namespace HotelBackend.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public int? IdTipo { get; set; }

    public string NumeroHabitacion { get; set; } = null!;

    public int? Piso { get; set; }

    public virtual TiposHabitacion? IdTipoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

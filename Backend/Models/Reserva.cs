using System;
using System.Collections.Generic;

namespace HotelBackend.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }
    public int? IdHuesped { get; set; }
    public int? IdHabitacion { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public DateOnly FechaSalida { get; set; }
    public int? CantidadPersonas { get; set; }
    public string? Estado { get; set; } = null!;
    public DateTime? FechaHoraCheckin { get; set; }
    public DateTime? FechaHoraCheckout { get; set; }
    public virtual Habitacione? IdHabitacionNavigation { get; set; }
    public virtual Huespede? IdHuespedNavigation { get; set; }
}

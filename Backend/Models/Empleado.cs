using System;
using System.Collections.Generic;

namespace HotelBackend.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual Role? IdRolNavigation { get; set; }

}

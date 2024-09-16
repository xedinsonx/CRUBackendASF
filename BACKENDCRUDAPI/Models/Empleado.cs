using System;
using System.Collections.Generic;

namespace BACKENDCRUDAPI.Models;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaIngreso { get; set; }

    public string? Afp { get; set; }

    public string Cargo { get; set; } = null!;

    public int Sueldo { get; set; }

    public int? Idcargo { get; set; }

    public virtual Cargo? IdcargoNavigation { get; set; }
    public object IDCARGONavigation { get; internal set; }
}

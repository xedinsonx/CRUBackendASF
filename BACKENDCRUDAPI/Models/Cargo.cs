using System;
using System.Collections.Generic;

namespace BACKENDCRUDAPI.Models;

public partial class Cargo
{
    public int Idcargo { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fecharegistro { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}

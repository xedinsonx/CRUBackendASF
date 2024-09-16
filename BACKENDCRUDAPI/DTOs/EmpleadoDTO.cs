namespace BACKENDCRUDAPI.DTOs
{
    public class EmpleadoDTO
    {
        public int Idempleado { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? FechaNacimiento { get; set; }

        public string? FechaIngreso { get; set; }

        public string? Afp { get; set; }

        public string Cargo { get; set; } = null!;

        public int Sueldo { get; set; }

        public int? Idcargo { get; set; }

        public string NombreCargo { get; set; } = null!;
    }
}

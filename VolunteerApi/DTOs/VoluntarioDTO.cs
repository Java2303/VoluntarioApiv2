namespace VolunteerApi.DTOs
{
    public class VoluntarioDTO
    {
        public int VoluntarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public DateOnly? FechaNac { get; set; }
        public string Domicilio { get; set; } = string.Empty;
        public string NumeroCelular { get; set; } = string.Empty;

        // Agregamos las propiedades para almacenar la información relacionada con Especialidad y Usuario
        public int? EspecialidadId { get; set; }  // Esto es para capturar el ID de la especialidad
        public string? Especialidad { get; set; }  // Esto es para capturar el nombre de la especialidad
        public int? UsuarioId { get; set; }  // Esto es para capturar el ID del Usuario
    }
}

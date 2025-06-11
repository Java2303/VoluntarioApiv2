using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VolunteerApi.Models
{
    public class SeguimientoSaludVoluntario
    {
        [Key] // Asegura que esta sea la Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Incrementable
        public int SeguimientoID { get; set; }
        public int VoluntarioID { get; set; }

        // Características Físicas
        public float Estatura { get; set; }
        public float Peso { get; set; }
        public string TipoSangre { get; set; }
        public string CondicionFisica { get; set; }

        // Historial Médico
        public string Alergias { get; set; }
        public string EnfermedadesCronicas { get; set; }
        public string Medicamentos { get; set; }
        public string EstadoVacunacion { get; set; }

        // Signos Vitales
        public int? FrecuenciaCardiaca { get; set; }
        public string PresionArterial { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public float? Temperatura { get; set; }

        // Salud Mental
        public string NivelEstres { get; set; }
        public float? HorasSueño { get; set; }
        public string EstadoAnimo { get; set; }

        // Actividad Física
        public string FrecuenciaEjercicio { get; set; }
        public string TipoActividad { get; set; }
        public int? DuracionEjercicio { get; set; }
    }
}

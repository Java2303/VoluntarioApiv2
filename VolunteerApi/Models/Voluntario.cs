using System;
using System.Collections.Generic;

namespace VolunteerApi.Models;

public partial class Voluntario
{
    public int VoluntarioId { get; set; }

    public int? UsuarioId { get; set; }

    public int? EspecialidadId { get; set; }

    public string? Sexo { get; set; }

    public DateOnly? FechaNac { get; set; }

    public string? Domicilio { get; set; }

    public string? NumeroCelular { get; set; }

    public virtual Especialidade? Especialidad { get; set; }

    public virtual ICollection<HistorialCapacitacion> HistorialCapacitacions { get; set; } = new List<HistorialCapacitacion>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    public virtual Usuario? Usuario { get; set; }
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

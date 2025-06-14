﻿using System;
using System.Collections.Generic;

namespace VolunteerApi.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int RolId { get; set; }

    public DateTime? FechaRegistro { get; set; } // Puede ser nula

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>(); // Puede estar vacío

    public virtual Role Rol { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>(); // Puede estar vacío

    public virtual Voluntario? Voluntario { get; set; } // Puede ser nulo
}

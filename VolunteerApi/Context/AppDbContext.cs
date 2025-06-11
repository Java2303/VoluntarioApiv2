using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using VolunteerApi.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Donadore> Donadores { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<HistorialCapacitacion> HistorialCapacitacions { get; set; }

    public virtual DbSet<Privilegio> Privilegios { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Voluntario> Voluntarios { get; set; }
    public virtual DbSet<SeguimientoSaludVoluntario> SeguimientoSaludVoluntarios { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E023A376FD61217");

            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.Dificultad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Donadore>(entity =>
        {
            entity.HasKey(e => e.DonadorId).HasName("PK__Donadore__D79B10BE5A61778E");

            entity.HasIndex(e => e.CiNit, "UQ__Donadore__2B8937240D6690EB").IsUnique();

            entity.Property(e => e.DonadorId).HasColumnName("DonadorID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.CiNit)
                .HasMaxLength(50)
                .HasColumnName("CI_NIT");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NumeroReferencia).HasMaxLength(20);
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.EspecialidadId).HasName("PK__Especial__F907181181A41B8F");

            entity.HasIndex(e => e.NombreEspecialidad, "UQ__Especial__448A2514E50ECBC4").IsUnique();

            entity.Property(e => e.EspecialidadId).HasColumnName("EspecialidadID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.NombreEspecialidad).HasMaxLength(100);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB590128839CF5");

            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.NombreEvento).HasMaxLength(255);
            entity.Property(e => e.OrganizadorId).HasColumnName("OrganizadorID");
            entity.Property(e => e.Ubicacion).HasMaxLength(255);

            entity.HasOne(d => d.Organizador).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.OrganizadorId)
                .HasConstraintName("FK__Eventos__Organiz__66603565");
        });

        modelBuilder.Entity<HistorialCapacitacion>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EFE6EA96FB");

            entity.ToTable("HistorialCapacitacion");

            entity.Property(e => e.HistorialId).HasColumnName("HistorialID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.VoluntarioId).HasColumnName("VoluntarioID");

            entity.HasOne(d => d.Curso).WithMany(p => p.HistorialCapacitacions)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Historial__Curso__5DCAEF64");

            entity.HasOne(d => d.Voluntario).WithMany(p => p.HistorialCapacitacions)
                .HasForeignKey(d => d.VoluntarioId)
                .HasConstraintName("FK__Historial__Volun__5CD6CB2B");
        });

        modelBuilder.Entity<Privilegio>(entity =>
        {
            entity.HasKey(e => e.PrivilegioId).HasName("PK__Privileg__8DB735BA409C3BE6");

            entity.HasIndex(e => e.NombrePrivilegio, "UQ__Privileg__668E88A12F621B72").IsUnique();

            entity.Property(e => e.PrivilegioId).HasColumnName("PrivilegioID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.NombrePrivilegio).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D156830D92");

            entity.HasIndex(e => e.NombreRol, "UQ__Roles__4F0B537F774CB6A2").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.NombreRol).HasMaxLength(50);

            entity.HasMany(d => d.Privilegios).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesPrivilegio",
                    r => r.HasOne<Privilegio>().WithMany()
                        .HasForeignKey("PrivilegioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RolesPriv__Privi__3D5E1FD2"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RolesPriv__RolID__3C69FB99"),
                    j =>
                    {
                        j.HasKey("RolId", "PrivilegioId").HasName("PK__RolesPri__41F8718A018018B3");
                        j.ToTable("RolesPrivilegios");
                        j.IndexerProperty<int>("RolId").HasColumnName("RolID");
                        j.IndexerProperty<int>("PrivilegioId").HasColumnName("PrivilegioID");
                    });
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tareas__5CD836712B58A928");

            entity.Property(e => e.TareaId).HasColumnName("TareaID");
            entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.VoluntarioId).HasColumnName("VoluntarioID");

            entity.HasOne(d => d.Administrador).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.AdministradorId)
                .HasConstraintName("FK__Tareas__Administ__6383C8BA");

            entity.HasOne(d => d.Voluntario).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.VoluntarioId)
                .HasConstraintName("FK__Tareas__Voluntar__628FA481");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7983B948D4C");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534056DEFBD").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__RolID__4222D4EF");
        });

        modelBuilder.Entity<Voluntario>(entity =>
        {
            entity.HasKey(e => e.VoluntarioId).HasName("PK__Voluntar__47C2E0FFE85F1AC6");

            entity.HasIndex(e => e.UsuarioId, "UQ__Voluntar__2B3DE799B920D6A5").IsUnique();

            entity.Property(e => e.VoluntarioId).HasColumnName("VoluntarioID");
            entity.Property(e => e.Domicilio).HasMaxLength(255);
            entity.Property(e => e.EspecialidadId).HasColumnName("EspecialidadID");
            entity.Property(e => e.NumeroCelular).HasMaxLength(20);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.Voluntarios)
                .HasForeignKey(d => d.EspecialidadId)
                .HasConstraintName("FK__Voluntari__Espec__571DF1D5");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Voluntario)
                .HasForeignKey<Voluntario>(d => d.UsuarioId)
                .HasConstraintName("FK__Voluntari__Usuar__5629CD9C");

            entity.HasMany(d => d.Eventos).WithMany(p => p.Voluntarios)
                .UsingEntity<Dictionary<string, object>>(
                    "VoluntariosEvento",
                    r => r.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Voluntari__Event__6A30C649"),
                    l => l.HasOne<Voluntario>().WithMany()
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Voluntari__Volun__693CA210"),
                    j =>
                    {
                        j.HasKey("VoluntarioId", "EventoId").HasName("PK__Voluntar__462C556F60FA8F90");
                        j.ToTable("VoluntariosEventos");
                        j.IndexerProperty<int>("VoluntarioId").HasColumnName("VoluntarioID");
                        j.IndexerProperty<int>("EventoId").HasColumnName("EventoID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

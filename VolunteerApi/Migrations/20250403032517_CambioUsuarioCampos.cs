using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteerApi.Migrations
{
    /// <inheritdoc />
    public partial class CambioUsuarioCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dificultad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cursos__7E023A376FD61217", x => x.CursoID);
                });

            migrationBuilder.CreateTable(
                name: "Donadores",
                columns: table => new
                {
                    DonadorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CI_NIT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroReferencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Donadore__D79B10BE5A61778E", x => x.DonadorID);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEspecialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especial__F907181181A41B8F", x => x.EspecialidadID);
                });

            migrationBuilder.CreateTable(
                name: "Privilegios",
                columns: table => new
                {
                    PrivilegioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePrivilegio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Privileg__8DB735BA409C3BE6", x => x.PrivilegioID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__F92302D156830D92", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "RolesPrivilegios",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false),
                    PrivilegioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RolesPri__41F8718A018018B3", x => new { x.RolID, x.PrivilegioID });
                    table.ForeignKey(
                        name: "FK__RolesPriv__Privi__3D5E1FD2",
                        column: x => x.PrivilegioID,
                        principalTable: "Privilegios",
                        principalColumn: "PrivilegioID");
                    table.ForeignKey(
                        name: "FK__RolesPriv__RolID__3C69FB99",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__2B3DE7983B948D4C", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK__Usuarios__RolID__4222D4EF",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrganizadorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Eventos__1EEB590128839CF5", x => x.EventoID);
                    table.ForeignKey(
                        name: "FK__Eventos__Organiz__66603565",
                        column: x => x.OrganizadorID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    VoluntarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    EspecialidadID = table.Column<int>(type: "int", nullable: true),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    FechaNac = table.Column<DateOnly>(type: "date", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NumeroCelular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voluntar__47C2E0FFE85F1AC6", x => x.VoluntarioID);
                    table.ForeignKey(
                        name: "FK__Voluntari__Espec__571DF1D5",
                        column: x => x.EspecialidadID,
                        principalTable: "Especialidades",
                        principalColumn: "EspecialidadID");
                    table.ForeignKey(
                        name: "FK__Voluntari__Usuar__5629CD9C",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "HistorialCapacitacion",
                columns: table => new
                {
                    HistorialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoluntarioID = table.Column<int>(type: "int", nullable: true),
                    CursoID = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historia__975206EFE6EA96FB", x => x.HistorialID);
                    table.ForeignKey(
                        name: "FK__Historial__Curso__5DCAEF64",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "CursoID");
                    table.ForeignKey(
                        name: "FK__Historial__Volun__5CD6CB2B",
                        column: x => x.VoluntarioID,
                        principalTable: "Voluntarios",
                        principalColumn: "VoluntarioID");
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaAsignacion = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    FechaLimite = table.Column<DateOnly>(type: "date", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VoluntarioID = table.Column<int>(type: "int", nullable: true),
                    AdministradorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tareas__5CD836712B58A928", x => x.TareaID);
                    table.ForeignKey(
                        name: "FK__Tareas__Administ__6383C8BA",
                        column: x => x.AdministradorID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                    table.ForeignKey(
                        name: "FK__Tareas__Voluntar__628FA481",
                        column: x => x.VoluntarioID,
                        principalTable: "Voluntarios",
                        principalColumn: "VoluntarioID");
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosEventos",
                columns: table => new
                {
                    VoluntarioID = table.Column<int>(type: "int", nullable: false),
                    EventoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voluntar__462C556F60FA8F90", x => new { x.VoluntarioID, x.EventoID });
                    table.ForeignKey(
                        name: "FK__Voluntari__Event__6A30C649",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoID");
                    table.ForeignKey(
                        name: "FK__Voluntari__Volun__693CA210",
                        column: x => x.VoluntarioID,
                        principalTable: "Voluntarios",
                        principalColumn: "VoluntarioID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Donadore__2B8937240D6690EB",
                table: "Donadores",
                column: "CI_NIT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Especial__448A2514E50ECBC4",
                table: "Especialidades",
                column: "NombreEspecialidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_OrganizadorID",
                table: "Eventos",
                column: "OrganizadorID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCapacitacion_CursoID",
                table: "HistorialCapacitacion",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCapacitacion_VoluntarioID",
                table: "HistorialCapacitacion",
                column: "VoluntarioID");

            migrationBuilder.CreateIndex(
                name: "UQ__Privileg__668E88A12F621B72",
                table: "Privilegios",
                column: "NombrePrivilegio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Roles__4F0B537F774CB6A2",
                table: "Roles",
                column: "NombreRol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesPrivilegios_PrivilegioID",
                table: "RolesPrivilegios",
                column: "PrivilegioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_AdministradorID",
                table: "Tareas",
                column: "AdministradorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_VoluntarioID",
                table: "Tareas",
                column: "VoluntarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__A9D10534056DEFBD",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_EspecialidadID",
                table: "Voluntarios",
                column: "EspecialidadID");

            migrationBuilder.CreateIndex(
                name: "UQ__Voluntar__2B3DE799B920D6A5",
                table: "Voluntarios",
                column: "UsuarioID",
                unique: true,
                filter: "[UsuarioID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosEventos_EventoID",
                table: "VoluntariosEventos",
                column: "EventoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donadores");

            migrationBuilder.DropTable(
                name: "HistorialCapacitacion");

            migrationBuilder.DropTable(
                name: "RolesPrivilegios");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "VoluntariosEventos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Privilegios");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

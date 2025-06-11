using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteerApi.Migrations
{
    /// <inheritdoc />
    public partial class CrearHistorialCapacitacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeguimientoSaludVoluntarios",
                columns: table => new
                {
                    SeguimientoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoluntarioID = table.Column<int>(type: "int", nullable: false),
                    Estatura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    TipoSangre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondicionFisica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnfermedadesCronicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoVacunacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaCardiaca = table.Column<int>(type: "int", nullable: true),
                    PresionArterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaRespiratoria = table.Column<int>(type: "int", nullable: true),
                    Temperatura = table.Column<float>(type: "real", nullable: true),
                    NivelEstres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorasSueño = table.Column<float>(type: "real", nullable: true),
                    EstadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaEjercicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoActividad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracionEjercicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoSaludVoluntarios", x => x.SeguimientoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeguimientoSaludVoluntarios");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenUnidad2.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Documento = table.Column<string>(type: "TEXT", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Departamento = table.Column<string>(type: "TEXT", nullable: true),
                    PuestoTrabajo = table.Column<string>(type: "TEXT", nullable: true),
                    SalarioBase = table.Column<float>(type: "REAL", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planillas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Periodo = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planillas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetallePlanillas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanillaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioBase = table.Column<float>(type: "REAL", nullable: false),
                    Horas_Extras = table.Column<float>(type: "REAL", nullable: false),
                    Monto_Horas_Extra = table.Column<float>(type: "REAL", nullable: false),
                    Bonificaciones = table.Column<float>(type: "REAL", nullable: false),
                    Deducciones = table.Column<float>(type: "REAL", nullable: false),
                    SalarioNeto = table.Column<float>(type: "REAL", nullable: false),
                    Comentarios = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePlanillas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePlanillas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePlanillas_Planillas_PlanillaId",
                        column: x => x.PlanillaId,
                        principalTable: "Planillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePlanillas_EmpleadoId",
                table: "DetallePlanillas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePlanillas_PlanillaId",
                table: "DetallePlanillas",
                column: "PlanillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePlanillas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Planillas");
        }
    }
}

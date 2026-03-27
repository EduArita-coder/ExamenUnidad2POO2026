using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenUnidad2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypesToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horas_Extras",
                table: "DetallePlanillas");

            migrationBuilder.RenameColumn(
                name: "Monto_Horas_Extra",
                table: "DetallePlanillas",
                newName: "MontoHorasExtra");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalarioBase",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalarioNeto",
                table: "DetallePlanillas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalarioBase",
                table: "DetallePlanillas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Deducciones",
                table: "DetallePlanillas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bonificaciones",
                table: "DetallePlanillas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontoHorasExtra",
                table: "DetallePlanillas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<decimal>(
                name: "HorasExtra",
                table: "DetallePlanillas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasExtra",
                table: "DetallePlanillas");

            migrationBuilder.RenameColumn(
                name: "MontoHorasExtra",
                table: "DetallePlanillas",
                newName: "Monto_Horas_Extra");

            migrationBuilder.AlterColumn<float>(
                name: "SalarioBase",
                table: "Empleados",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "SalarioNeto",
                table: "DetallePlanillas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "SalarioBase",
                table: "DetallePlanillas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "Deducciones",
                table: "DetallePlanillas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "Bonificaciones",
                table: "DetallePlanillas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "Monto_Horas_Extra",
                table: "DetallePlanillas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<float>(
                name: "Horas_Extras",
                table: "DetallePlanillas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoGym.Migrations
{
    /// <inheritdoc />
    public partial class tuneoEntrenadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "numeroTelefono",
                table: "Entrenador",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "numeroTelefono",
                table: "Entrenador",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

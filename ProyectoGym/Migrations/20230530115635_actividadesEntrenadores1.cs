using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoGym.Migrations
{
    /// <inheritdoc />
    public partial class actividadesEntrenadores1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEntrenador",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdEntrenador",
                table: "Actividades",
                column: "IdEntrenador");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Entrenador_IdEntrenador",
                table: "Actividades",
                column: "IdEntrenador",
                principalTable: "Entrenador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Entrenador_IdEntrenador",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_IdEntrenador",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "IdEntrenador",
                table: "Actividades");
        }
    }
}

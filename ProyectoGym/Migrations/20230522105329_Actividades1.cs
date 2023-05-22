using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoGym.Migrations
{
    /// <inheritdoc />
    public partial class Actividades1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActividadesId",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ActividadesId",
                table: "Citas",
                column: "ActividadesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Actividades_ActividadesId",
                table: "Citas",
                column: "ActividadesId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Actividades_ActividadesId",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Citas_ActividadesId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "ActividadesId",
                table: "Citas");
        }
    }
}

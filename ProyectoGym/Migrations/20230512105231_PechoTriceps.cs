using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoGym.Migrations
{
    /// <inheritdoc />
    public partial class PechoTriceps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EjerciciosPechoTriceps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeticiones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ulrVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerciciosPechoTriceps", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EjerciciosPechoTriceps");
        }
    }
}

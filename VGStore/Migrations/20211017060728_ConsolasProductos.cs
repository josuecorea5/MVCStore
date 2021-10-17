using Microsoft.EntityFrameworkCore.Migrations;

namespace VGStore.Migrations
{
    public partial class ConsolasProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdConsole",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdConsole",
                table: "Productos",
                column: "IdConsole");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Consoles_IdConsole",
                table: "Productos",
                column: "IdConsole",
                principalTable: "Consoles",
                principalColumn: "IdConsole",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Consoles_IdConsole",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdConsole",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdConsole",
                table: "Productos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace VGStore.Migrations
{
    public partial class agregarProductosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categories_IdCategoria",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Productos",
                newName: "IdCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                newName: "IX_Productos_IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categories_IdCategory",
                table: "Productos",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categories_IdCategory",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Productos",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdCategory",
                table: "Productos",
                newName: "IX_Productos_IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categories_IdCategoria",
                table: "Productos",
                column: "IdCategoria",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

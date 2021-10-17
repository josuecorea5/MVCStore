using Microsoft.EntityFrameworkCore.Migrations;

namespace VGStore.Migrations
{
    public partial class descripcionCortaProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescripcionCorta",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionCorta",
                table: "Productos");
        }
    }
}

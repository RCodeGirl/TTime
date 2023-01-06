using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenProject.Data.Migrations
{
    public partial class External : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isExternal",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isExternal",
                table: "MenuItems");
        }
    }
}

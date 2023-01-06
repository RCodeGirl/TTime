using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenProject.Data.Migrations
{
    public partial class PositionBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pozition",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pozition",
                table: "Blocks");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenProject.Data.Migrations
{
    public partial class positionBlockList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pozition",
                table: "BlockLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pozition",
                table: "BlockLists");
        }
    }
}

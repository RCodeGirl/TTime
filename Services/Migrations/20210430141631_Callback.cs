using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenProject.Data.Migrations
{
    public partial class Callback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Callbacks",
                newName: "LanguageTarget");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Callbacks",
                newName: "LanguageOrig");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Callbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doc",
                table: "Callbacks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Callbacks");

            migrationBuilder.DropColumn(
                name: "Doc",
                table: "Callbacks");

            migrationBuilder.RenameColumn(
                name: "LanguageTarget",
                table: "Callbacks",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "LanguageOrig",
                table: "Callbacks",
                newName: "Contact");
        }
    }
}

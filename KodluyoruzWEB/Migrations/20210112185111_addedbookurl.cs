using Microsoft.EntityFrameworkCore.Migrations;

namespace KodluyoruzWEB.Migrations
{
    public partial class addedbookurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bookPdfUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookPdfUrl",
                table: "Books");
        }
    }
}

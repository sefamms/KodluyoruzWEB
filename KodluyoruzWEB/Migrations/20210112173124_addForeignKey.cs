using Microsoft.EntityFrameworkCore.Migrations;

namespace KodluyoruzWEB.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_Booksid",
                table: "BookGallery");

            migrationBuilder.DropIndex(
                name: "IX_BookGallery_Booksid",
                table: "BookGallery");

            migrationBuilder.DropColumn(
                name: "Booksid",
                table: "BookGallery");

            migrationBuilder.CreateIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery");

            migrationBuilder.DropIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGallery");

            migrationBuilder.AddColumn<int>(
                name: "Booksid",
                table: "BookGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookGallery_Booksid",
                table: "BookGallery",
                column: "Booksid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_Booksid",
                table: "BookGallery",
                column: "Booksid",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

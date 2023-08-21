using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Country", "FirstName", "LastName" },
                values: new object[] { 1, 1, "asda", "asf", "gf" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "PublicationYear", "Rating", "Title" },
                values: new object[] { 1, 1, "Description", "978-3-16-148410-0", 1245, 9, "Title" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Books");
        }
    }
}

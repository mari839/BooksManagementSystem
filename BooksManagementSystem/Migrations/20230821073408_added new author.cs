using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addednewauthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Country", "FirstName", "LastName" },
                values: new object[] { 2, 22, "mari", "tandashvili", "gsadasff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

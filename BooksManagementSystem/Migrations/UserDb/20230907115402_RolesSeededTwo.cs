using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksManagementSystem.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class RolesSeededTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf8228c-2bc5-4f3a-a782-3cc28767d723");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9d2424c-6802-4030-8ef2-c64381a737c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b7c077a-f2a3-48ef-a8dd-79b4cdfb1604", "1", "Admin", "Admin" },
                    { "def21ef3-edc1-4b1b-8a66-44fe1492d858", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b7c077a-f2a3-48ef-a8dd-79b4cdfb1604");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "def21ef3-edc1-4b1b-8a66-44fe1492d858");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bf8228c-2bc5-4f3a-a782-3cc28767d723", "1", "Admin", "Admin" },
                    { "a9d2424c-6802-4030-8ef2-c64381a737c3", "2", "User", "User" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoFetchGrooming.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPetTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "PetTypeId", "PetTypeName" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 2);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoFetchGrooming.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedServiceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "ServiceDescription", "ServiceName", "ServicePrice" },
                values: new object[,]
                {
                    { 1, "Complete body wash for pets.", "Full Body Wash", 0.0 },
                    { 2, "Remove excess shedding.", "De-Shedding", 0.0 },
                    { 3, "Complete grooming for dogs.", "Dog Grooming", 0.0 },
                    { 4, "Trimming and shaping of dog nails.", "Dog Nail Trimming", 0.0 },
                    { 5, "Trimming and shaping of cat nails.", "Cat Nail Trimming", 0.0 },
                    { 6, "Gentle cleaning of pet ears.", "Ear Cleaning", 0.0 },
                    { 7, "Teeth brushing for pets.", "Tooth Brushing", 0.0 },
                    { 8, "Helps maintain pet gland health.", "Gland Expression", 0.0 },
                    { 9, "Regular brushing to remove tangles.", "Brushing", 0.0 },
                    { 10, "Treatment to remove fleas.", "Flea Control", 0.0 },
                    { 11, "Special haircuts based on breed.", "Breed Specific Haircuts", 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 11);
        }
    }
}

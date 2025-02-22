using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoFetchGrooming.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePetList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetLists_PetListId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "PetLists");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetListId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetListId",
                table: "Pets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetListId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PetLists",
                columns: table => new
                {
                    PetListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetLists", x => x.PetListId);
                    table.ForeignKey(
                        name: "FK_PetLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetListId",
                table: "Pets",
                column: "PetListId");

            migrationBuilder.CreateIndex(
                name: "IX_PetLists_UserId",
                table: "PetLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetLists_PetListId",
                table: "Pets",
                column: "PetListId",
                principalTable: "PetLists",
                principalColumn: "PetListId");
        }
    }
}

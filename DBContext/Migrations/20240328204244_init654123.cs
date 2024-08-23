using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class init654123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "branshes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_branshes_UserId",
                table: "branshes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_branshes_User_UserId",
                table: "branshes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branshes_User_UserId",
                table: "branshes");

            migrationBuilder.DropIndex(
                name: "IX_branshes_UserId",
                table: "branshes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "branshes");
        }
    }
}

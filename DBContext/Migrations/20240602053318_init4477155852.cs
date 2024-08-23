using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class init4477155852 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "braId",
                table: "Responses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_braId",
                table: "Responses",
                column: "braId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_branshes_braId",
                table: "Responses",
                column: "braId",
                principalTable: "branshes",
                principalColumn: "brannum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_branshes_braId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_braId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "braId",
                table: "Responses");
        }
    }
}

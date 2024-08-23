using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class i6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla");

            migrationBuilder.DropForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_PurshesOrderid",
                table: "kemiesHomolla");

            migrationBuilder.DropIndex(
                name: "IX_kemiesHomolla_PurshesOrderid",
                table: "kemiesHomolla");

            migrationBuilder.DropIndex(
                name: "IX_dependsHomolla_PrId",
                table: "dependsHomolla");

            migrationBuilder.DropColumn(
                name: "PurshesOrderid",
                table: "kemiesHomolla");

            migrationBuilder.CreateIndex(
                name: "IX_kemiesHomolla_mizeNum",
                table: "kemiesHomolla",
                column: "mizeNum");

            migrationBuilder.CreateIndex(
                name: "IX_dependsHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId",
                unique: true,
                filter: "[PrId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId",
                principalTable: "mizePursHomolla",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_mizeNum",
                table: "kemiesHomolla",
                column: "mizeNum",
                principalTable: "mizePursHomolla",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla");

            migrationBuilder.DropForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_mizeNum",
                table: "kemiesHomolla");

            migrationBuilder.DropIndex(
                name: "IX_kemiesHomolla_mizeNum",
                table: "kemiesHomolla");

            migrationBuilder.DropIndex(
                name: "IX_dependsHomolla_PrId",
                table: "dependsHomolla");

            migrationBuilder.AddColumn<int>(
                name: "PurshesOrderid",
                table: "kemiesHomolla",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_kemiesHomolla_PurshesOrderid",
                table: "kemiesHomolla",
                column: "PurshesOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_dependsHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId");

            migrationBuilder.AddForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId",
                principalTable: "mizePursHomolla",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_PurshesOrderid",
                table: "kemiesHomolla",
                column: "PurshesOrderid",
                principalTable: "mizePursHomolla",
                principalColumn: "id");
        }
    }
}

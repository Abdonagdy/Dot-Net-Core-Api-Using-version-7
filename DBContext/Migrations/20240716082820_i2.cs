using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class i2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_mizeNum",
                table: "kemiesHomolla");

            migrationBuilder.DropIndex(
                name: "IX_kemiesHomolla_mizeNum",
                table: "kemiesHomolla");

            migrationBuilder.AddColumn<int>(
                name: "PurshesOrderid",
                table: "kemiesHomolla",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_kemiesHomolla_PurshesOrderid",
                table: "kemiesHomolla",
                column: "PurshesOrderid");

            migrationBuilder.AddForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_PurshesOrderid",
                table: "kemiesHomolla",
                column: "PurshesOrderid",
                principalTable: "mizePursHomolla",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_PurshesOrderid",
                table: "kemiesHomolla");

            migrationBuilder.DropIndex(
                name: "IX_kemiesHomolla_PurshesOrderid",
                table: "kemiesHomolla");

            migrationBuilder.DropColumn(
                name: "PurshesOrderid",
                table: "kemiesHomolla");

            migrationBuilder.CreateIndex(
                name: "IX_kemiesHomolla_mizeNum",
                table: "kemiesHomolla",
                column: "mizeNum");

            migrationBuilder.AddForeignKey(
                name: "FK_kemiesHomolla_mizePursHomolla_mizeNum",
                table: "kemiesHomolla",
                column: "mizeNum",
                principalTable: "mizePursHomolla",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

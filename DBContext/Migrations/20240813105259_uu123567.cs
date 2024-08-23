using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class uu123567 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mowardsHomolaa_AspNetUsers_UserID",
                table: "mowardsHomolaa");

            migrationBuilder.DropIndex(
                name: "IX_mowardsHomolaa_UserID",
                table: "mowardsHomolaa");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "mowardsHomolaa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "mowardsHomolaa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mowardsHomolaa_UserID",
                table: "mowardsHomolaa",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_mowardsHomolaa_AspNetUsers_UserID",
                table: "mowardsHomolaa",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

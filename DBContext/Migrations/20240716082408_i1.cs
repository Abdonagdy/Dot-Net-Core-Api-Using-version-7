using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla");

            migrationBuilder.AlterColumn<int>(
                name: "PrId",
                table: "dependsHomolla",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId",
                principalTable: "mizePursHomolla",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla");

            migrationBuilder.AlterColumn<int>(
                name: "PrId",
                table: "dependsHomolla",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dependsHomolla_mizePursHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId",
                principalTable: "mizePursHomolla",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

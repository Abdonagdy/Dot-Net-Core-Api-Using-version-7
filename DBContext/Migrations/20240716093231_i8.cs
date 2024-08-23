using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class i8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_depends_PrId",
                table: "depends");

            migrationBuilder.AlterColumn<int>(
                name: "mizeNum",
                table: "kemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_depends_PrId",
                table: "depends",
                column: "PrId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_depends_PrId",
                table: "depends");

            migrationBuilder.AlterColumn<int>(
                name: "mizeNum",
                table: "kemies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_depends_PrId",
                table: "depends",
                column: "PrId");
        }
    }
}

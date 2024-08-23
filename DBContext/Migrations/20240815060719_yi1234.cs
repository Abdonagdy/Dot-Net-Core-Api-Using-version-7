using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class yi1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFName",
                table: "mizePurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userPhone",
                table: "mizePurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "kemies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Unitprice",
                table: "kemies",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFName",
                table: "mizePurs");

            migrationBuilder.DropColumn(
                name: "userPhone",
                table: "mizePurs");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "kemies");

            migrationBuilder.DropColumn(
                name: "Unitprice",
                table: "kemies");
        }
    }
}

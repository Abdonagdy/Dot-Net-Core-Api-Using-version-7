using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class init91763245 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmpId",
                table: "Responses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_EmpId",
                table: "Responses",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Employees_EmpId",
                table: "Responses",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Employees_EmpId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_EmpId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Responses");
        }
    }
}

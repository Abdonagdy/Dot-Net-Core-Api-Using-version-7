using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class init99887766 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpNum = table.Column<long>(type: "bigint", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    braId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpNum);
                    table.ForeignKey(
                        name: "FK_Employees_branshes_braId",
                        column: x => x.braId,
                        principalTable: "branshes",
                        principalColumn: "brannum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_braId",
                table: "Employees",
                column: "braId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

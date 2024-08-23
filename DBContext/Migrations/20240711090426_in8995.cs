using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class in8995 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mizePursHomolla",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClientNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Hekal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MordName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CarNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mizePursHomolla", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dependsHomolla",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDepend = table.Column<bool>(type: "bit", nullable: false),
                    PrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependsHomolla", x => x.id);
                    table.ForeignKey(
                        name: "FK_dependsHomolla_mizePursHomolla_PrId",
                        column: x => x.PrId,
                        principalTable: "mizePursHomolla",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kemiesHomolla",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kem = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    res = table.Column<double>(type: "float", nullable: false),
                    mizeNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kemiesHomolla", x => x.id);
                    table.ForeignKey(
                        name: "FK_kemiesHomolla_mizePursHomolla_mizeNum",
                        column: x => x.mizeNum,
                        principalTable: "mizePursHomolla",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dependsHomolla_PrId",
                table: "dependsHomolla",
                column: "PrId");

            migrationBuilder.CreateIndex(
                name: "IX_kemiesHomolla_mizeNum",
                table: "kemiesHomolla",
                column: "mizeNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dependsHomolla");

            migrationBuilder.DropTable(
                name: "kemiesHomolla");

            migrationBuilder.DropTable(
                name: "mizePursHomolla");
        }
    }
}

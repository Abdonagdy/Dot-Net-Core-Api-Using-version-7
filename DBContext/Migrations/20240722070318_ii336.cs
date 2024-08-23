using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class ii336 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Address_AddressId",
                table: "UserAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Address_AddressId",
                table: "UserAddress",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Address_AddressId",
                table: "UserAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Address_AddressId",
                table: "UserAddress",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}

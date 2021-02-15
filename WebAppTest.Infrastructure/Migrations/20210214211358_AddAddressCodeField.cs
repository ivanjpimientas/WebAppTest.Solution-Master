using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppTest.Infrastructure.Migrations
{
    public partial class AddAddressCodeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressCode",
                table: "Addresses",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressCode",
                table: "Addresses");
        }
    }
}

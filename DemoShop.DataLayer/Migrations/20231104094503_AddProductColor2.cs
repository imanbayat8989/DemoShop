using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoShop.DataLayer.Migrations
{
    public partial class AddProductColor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "ProductColors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "ProductColors");
        }
    }
}

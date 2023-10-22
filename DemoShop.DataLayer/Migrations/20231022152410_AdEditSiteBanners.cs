using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoShop.DataLayer.Migrations
{
    public partial class AdEditSiteBanners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BannerPlacement",
                table: "SiteBanner",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerPlacement",
                table: "SiteBanner");
        }
    }
}

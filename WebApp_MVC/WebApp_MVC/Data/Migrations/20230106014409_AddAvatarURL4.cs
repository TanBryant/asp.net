using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_MVC.Data.Migrations
{
    public partial class AddAvatarURL4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl4",
                table: "Product",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUrl4",
                table: "Product");
        }
    }
}

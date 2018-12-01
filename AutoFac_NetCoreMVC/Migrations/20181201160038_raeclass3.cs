using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoFac_NetCoreMVC.Migrations
{
    public partial class raeclass3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "ReadContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "ReadContent",
                nullable: false,
                defaultValue: 0);
        }
    }
}

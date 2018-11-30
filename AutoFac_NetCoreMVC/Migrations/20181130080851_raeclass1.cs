using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoFac_NetCoreMVC.Migrations
{
    public partial class raeclass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ReadContent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FNumber = table.Column<string>(nullable: true),
                    FName = table.Column<string>(nullable: true),
                    FLevel = table.Column<string>(nullable: true),
                    FJsonData = table.Column<string>(nullable: true),
                    FCreateTime = table.Column<DateTime>(nullable: false),
                    FModifyTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadContent", x => x.FId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadContent",
                schema: "dbo");
        }
    }
}

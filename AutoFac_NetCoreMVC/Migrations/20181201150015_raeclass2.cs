using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoFac_NetCoreMVC.Migrations
{
    public partial class raeclass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogRequest",
                schema: "dbo",
                columns: table => new
                {
                    FId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FName = table.Column<string>(nullable: true),
                    FRequestUrl = table.Column<string>(nullable: true),
                    FRequestType = table.Column<string>(nullable: true),
                    FParameters = table.Column<string>(nullable: true),
                    FMessage = table.Column<string>(nullable: true),
                    FDetails = table.Column<string>(nullable: true),
                    FIPAddress = table.Column<string>(nullable: true),
                    FRequestUser = table.Column<string>(nullable: true),
                    FRequestTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRequest", x => x.FId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogRequest",
                schema: "dbo");
        }
    }
}

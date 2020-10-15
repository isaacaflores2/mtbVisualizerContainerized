using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Summary.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummaryUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LastDownload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MonthSummaryActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ActvityID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Distance = table.Column<float>(nullable: true),
                    ElapsedTime = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthSummaryActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthSummaryActivities_SummaryUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SummaryUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthSummaryActivities_UserId",
                table: "MonthSummaryActivities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthSummaryActivities");

            migrationBuilder.DropTable(
                name: "SummaryUsers");
        }
    }
}

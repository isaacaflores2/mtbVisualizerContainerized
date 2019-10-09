using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StravaVisualizer.Migrations
{
    public partial class AddedStravaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisualActivities_MetaAthlete_Summary_AthleteId",
                table: "VisualActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_VisualActivities_StravaUsers_StravaUserUserId",
                table: "VisualActivities");

            migrationBuilder.DropTable(
                name: "MetaAthlete");

            migrationBuilder.DropIndex(
                name: "IX_VisualActivities_Summary_AthleteId",
                table: "VisualActivities");

            migrationBuilder.DropColumn(
                name: "Summary_AthleteId",
                table: "VisualActivities");

            migrationBuilder.RenameColumn(
                name: "StravaUserUserId",
                table: "VisualActivities",
                newName: "StravaUserId");

            migrationBuilder.RenameIndex(
                name: "IX_VisualActivities_StravaUserUserId",
                table: "VisualActivities",
                newName: "IX_VisualActivities_StravaUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StravaUsers",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "StravaId",
                table: "StravaUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_VisualActivities_StravaUsers_StravaUserId",
                table: "VisualActivities",
                column: "StravaUserId",
                principalTable: "StravaUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisualActivities_StravaUsers_StravaUserId",
                table: "VisualActivities");

            migrationBuilder.DropColumn(
                name: "StravaId",
                table: "StravaUsers");

            migrationBuilder.RenameColumn(
                name: "StravaUserId",
                table: "VisualActivities",
                newName: "StravaUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_VisualActivities_StravaUserId",
                table: "VisualActivities",
                newName: "IX_VisualActivities_StravaUserUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StravaUsers",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "Summary_AthleteId",
                table: "VisualActivities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MetaAthlete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaAthlete", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisualActivities_Summary_AthleteId",
                table: "VisualActivities",
                column: "Summary_AthleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisualActivities_MetaAthlete_Summary_AthleteId",
                table: "VisualActivities",
                column: "Summary_AthleteId",
                principalTable: "MetaAthlete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VisualActivities_StravaUsers_StravaUserUserId",
                table: "VisualActivities",
                column: "StravaUserUserId",
                principalTable: "StravaUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

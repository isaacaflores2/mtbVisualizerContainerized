using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StravaVisualizer.Migrations
{
    public partial class UpdatedStravaUserandVIsualActivity : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisualActivities",
                table: "VisualActivities");

            migrationBuilder.DropIndex(
                name: "IX_VisualActivities_Summary_AthleteId",
                table: "VisualActivities");

            migrationBuilder.DropColumn(
                name: "Summary_AthleteId",
                table: "VisualActivities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VisualActivities",
                newName: "Summary_Id");

            migrationBuilder.RenameColumn(
                name: "StravaUserUserId",
                table: "VisualActivities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VisualActivities_StravaUserUserId",
                table: "VisualActivities",
                newName: "IX_VisualActivities_UserId");

            migrationBuilder.AlterColumn<long>(
                name: "Summary_Id",
                table: "VisualActivities",
                nullable: true,
                oldClrType: typeof(long))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                table: "VisualActivities",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisualActivities",
                table: "VisualActivities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisualActivities_StravaUsers_UserId",
                table: "VisualActivities",
                column: "UserId",
                principalTable: "StravaUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisualActivities_StravaUsers_UserId",
                table: "VisualActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisualActivities",
                table: "VisualActivities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "VisualActivities");

            migrationBuilder.RenameColumn(
                name: "Summary_Id",
                table: "VisualActivities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "VisualActivities",
                newName: "StravaUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_VisualActivities_UserId",
                table: "VisualActivities",
                newName: "IX_VisualActivities_StravaUserUserId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "VisualActivities",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Summary_AthleteId",
                table: "VisualActivities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisualActivities",
                table: "VisualActivities",
                column: "Id");

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

﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StravaVisualizer.Migrations
{
    public partial class VisualActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "PolylineMap",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Polyline = table.Column<string>(nullable: true),
                    SummaryPolyline = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolylineMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StravaUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastDownload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StravaUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VisualActivities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartLat = table.Column<float>(nullable: true),
                    StartLong = table.Column<float>(nullable: true),
                    EndLat = table.Column<float>(nullable: true),
                    EndLong = table.Column<float>(nullable: true),
                    TrailName = table.Column<string>(nullable: true),
                    Summary_ExternalId = table.Column<string>(nullable: true),
                    Summary_UploadId = table.Column<long>(nullable: true),
                    Summary_AthleteId = table.Column<int>(nullable: true),
                    Summary_Name = table.Column<string>(nullable: true),
                    Summary_Distance = table.Column<float>(nullable: true),
                    Summary_MovingTime = table.Column<int>(nullable: true),
                    Summary_ElapsedTime = table.Column<int>(nullable: true),
                    Summary_TotalElevationGain = table.Column<float>(nullable: true),
                    Summary_ElevHigh = table.Column<float>(nullable: true),
                    Summary_ElevLow = table.Column<float>(nullable: true),
                    Summary_Type = table.Column<int>(nullable: false),
                    Summary_StartDate = table.Column<DateTime>(nullable: true),
                    Summary_StartDateLocal = table.Column<DateTime>(nullable: true),
                    Summary_Timezone = table.Column<string>(nullable: true),
                    Summary_AchievementCount = table.Column<int>(nullable: true),
                    Summary_KudosCount = table.Column<int>(nullable: true),
                    Summary_CommentCount = table.Column<int>(nullable: true),
                    Summary_AthleteCount = table.Column<int>(nullable: true),
                    Summary_PhotoCount = table.Column<int>(nullable: true),
                    Summary_TotalPhotoCount = table.Column<int>(nullable: true),
                    Summary_MapId = table.Column<string>(nullable: true),
                    Summary_Trainer = table.Column<bool>(nullable: true),
                    Summary_Commute = table.Column<bool>(nullable: true),
                    Summary_Manual = table.Column<bool>(nullable: true),
                    Summary_Private = table.Column<bool>(nullable: true),
                    Summary_Flagged = table.Column<bool>(nullable: true),
                    Summary_WorkoutType = table.Column<int>(nullable: true),
                    Summary_UploadIdStr = table.Column<string>(nullable: true),
                    Summary_AverageSpeed = table.Column<float>(nullable: true),
                    Summary_MaxSpeed = table.Column<float>(nullable: true),
                    Summary_HasKudoed = table.Column<bool>(nullable: true),
                    Summary_GearId = table.Column<string>(nullable: true),
                    Summary_Kilojoules = table.Column<float>(nullable: true),
                    Summary_AverageWatts = table.Column<float>(nullable: true),
                    Summary_DeviceWatts = table.Column<bool>(nullable: true),
                    Summary_MaxWatts = table.Column<int>(nullable: true),
                    Summary_WeightedAverageWatts = table.Column<int>(nullable: true),
                    StravaUserUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisualActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisualActivities_MetaAthlete_Summary_AthleteId",
                        column: x => x.Summary_AthleteId,
                        principalTable: "MetaAthlete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisualActivities_PolylineMap_Summary_MapId",
                        column: x => x.Summary_MapId,
                        principalTable: "PolylineMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisualActivities_StravaUsers_StravaUserUserId",
                        column: x => x.StravaUserUserId,
                        principalTable: "StravaUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisualActivities_Summary_AthleteId",
                table: "VisualActivities",
                column: "Summary_AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_VisualActivities_Summary_MapId",
                table: "VisualActivities",
                column: "Summary_MapId");

            migrationBuilder.CreateIndex(
                name: "IX_VisualActivities_StravaUserUserId",
                table: "VisualActivities",
                column: "StravaUserUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisualActivities");

            migrationBuilder.DropTable(
                name: "MetaAthlete");

            migrationBuilder.DropTable(
                name: "PolylineMap");

            migrationBuilder.DropTable(
                name: "StravaUsers");
        }
    }
}

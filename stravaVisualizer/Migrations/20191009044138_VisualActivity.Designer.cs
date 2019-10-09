﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stravaVisualizer.Data;

namespace StravaVisualizer.Migrations
{
    [DbContext(typeof(StravaVisualizerDbContext))]
    [Migration("20191009044138_VisualActivity")]
    partial class VisualActivity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IO.Swagger.Model.MetaAthlete", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("MetaAthlete");
                });

            modelBuilder.Entity("IO.Swagger.Model.PolylineMap", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Polyline");

                    b.Property<string>("SummaryPolyline");

                    b.HasKey("Id");

                    b.ToTable("PolylineMap");
                });

            modelBuilder.Entity("StravaVisualizer.Models.Activities.StravaUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastDownload");

                    b.HasKey("UserId");

                    b.ToTable("StravaUsers");
                });

            modelBuilder.Entity("StravaVisualizer.Models.Activities.VisualActivity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("EndLat");

                    b.Property<float?>("EndLong");

                    b.Property<float?>("StartLat");

                    b.Property<float?>("StartLong");

                    b.Property<int?>("StravaUserUserId");

                    b.Property<string>("TrailName");

                    b.HasKey("Id");

                    b.HasIndex("StravaUserUserId");

                    b.ToTable("VisualActivities");
                });

            modelBuilder.Entity("StravaVisualizer.Models.Activities.VisualActivity", b =>
                {
                    b.HasOne("StravaVisualizer.Models.Activities.StravaUser")
                        .WithMany("VisualActivities")
                        .HasForeignKey("StravaUserUserId");

                    b.OwnsOne("IO.Swagger.Model.SummaryActivity", "Summary", b1 =>
                        {
                            b1.Property<long?>("Id")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int?>("AchievementCount");

                            b1.Property<int?>("AthleteCount");

                            b1.Property<int?>("AthleteId");

                            b1.Property<float?>("AverageSpeed");

                            b1.Property<float?>("AverageWatts");

                            b1.Property<int?>("CommentCount");

                            b1.Property<bool?>("Commute");

                            b1.Property<bool?>("DeviceWatts");

                            b1.Property<float?>("Distance");

                            b1.Property<int?>("ElapsedTime");

                            b1.Property<float?>("ElevHigh");

                            b1.Property<float?>("ElevLow");

                            b1.Property<string>("ExternalId");

                            b1.Property<bool?>("Flagged");

                            b1.Property<string>("GearId");

                            b1.Property<bool?>("HasKudoed");

                            b1.Property<float?>("Kilojoules");

                            b1.Property<int?>("KudosCount");

                            b1.Property<bool?>("Manual");

                            b1.Property<string>("MapId");

                            b1.Property<float?>("MaxSpeed");

                            b1.Property<int?>("MaxWatts");

                            b1.Property<int?>("MovingTime");

                            b1.Property<string>("Name");

                            b1.Property<int?>("PhotoCount");

                            b1.Property<bool?>("Private");

                            b1.Property<DateTime?>("StartDate");

                            b1.Property<DateTime?>("StartDateLocal");

                            b1.Property<string>("Timezone");

                            b1.Property<float?>("TotalElevationGain");

                            b1.Property<int?>("TotalPhotoCount");

                            b1.Property<bool?>("Trainer");

                            b1.Property<int>("Type");

                            b1.Property<long?>("UploadId");

                            b1.Property<string>("UploadIdStr");

                            b1.Property<int?>("WeightedAverageWatts");

                            b1.Property<int?>("WorkoutType");

                            b1.HasKey("Id");

                            b1.HasIndex("AthleteId");

                            b1.HasIndex("MapId");

                            b1.ToTable("VisualActivities");

                            b1.HasOne("IO.Swagger.Model.MetaAthlete", "Athlete")
                                .WithMany()
                                .HasForeignKey("AthleteId");

                            b1.HasOne("StravaVisualizer.Models.Activities.VisualActivity")
                                .WithOne("Summary")
                                .HasForeignKey("IO.Swagger.Model.SummaryActivity", "Id")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasOne("IO.Swagger.Model.PolylineMap", "Map")
                                .WithMany()
                                .HasForeignKey("MapId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
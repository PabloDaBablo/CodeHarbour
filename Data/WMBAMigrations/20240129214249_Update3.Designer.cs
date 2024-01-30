﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WMBA_7_2_.Data;

#nullable disable

namespace WMBA_7_2_.Data.WMBAMigrations
{
    [DbContext(typeof(WMBAContext))]
    [Migration("20240129214249_Update3")]
    partial class Update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("WMBA_7_2_.Models.Coach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoachMemberID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoachName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("CoachNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoachPosition")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Divisions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DivAge")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DivisionTeams")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LeagueID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueTypeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LeagueID");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Line_UpID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScheduleID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("Line_UpID");

                    b.HasIndex("ScheduleID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.League", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LeagueType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Line_Ups");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up_Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Line_UpID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("Line_UpID");

                    b.ToTable("Line_Up_Players");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerFirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerLastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerMemberID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.PlayerPosition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("PlayerPositions");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ScheduleDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ScheduleLocation")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("ScheduleSeason")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ScheduleTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Security", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecRID")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecUser")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Security");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.SecurityRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecRRole")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("SecurityRoles");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Stats", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerStatsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamStatsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("TeamID");

                    b.HasIndex("TeamStatsID");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoachID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerID1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CoachID");

                    b.HasIndex("PlayerID1");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.TeamStats", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamStatsLoss")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamStatsPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamStatsTies")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamStatsWins")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TeamID")
                        .IsUnique();

                    b.ToTable("Team_Stats");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team_Coach", b =>
                {
                    b.Property<int>("CoachID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoachID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("Team_Coaches");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team_Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AwayTeam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("GameID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeTeam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("LineUpID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Team_Games");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Divisions", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.League", "League")
                        .WithMany("Divisions")
                        .HasForeignKey("LeagueID");

                    b.Navigation("League");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Game", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Line_Up", null)
                        .WithMany("Games")
                        .HasForeignKey("Line_UpID");

                    b.HasOne("WMBA_7_2_.Models.Schedule", null)
                        .WithMany("Games")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up_Player", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Line_Up", null)
                        .WithMany("LineUps")
                        .HasForeignKey("Line_UpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Player", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Stats", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Player", "Player")
                        .WithMany("StatsTotal")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithMany("StatsTotal")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.TeamStats", "TeamStats")
                        .WithMany("StatsTotal")
                        .HasForeignKey("TeamStatsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");

                    b.Navigation("TeamStats");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID1");

                    b.Navigation("Coach");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.TeamStats", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithOne("TeamStats")
                        .HasForeignKey("WMBA_7_2_.Models.TeamStats", "TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team_Coach", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Coach", "Coach")
                        .WithMany("TeamCoach")
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithMany("TeamCoaches")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Coach", b =>
                {
                    b.Navigation("TeamCoach");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.League", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("LineUps");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Player", b =>
                {
                    b.Navigation("StatsTotal");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Schedule", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("StatsTotal");

                    b.Navigation("TeamCoaches");

                    b.Navigation("TeamStats");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.TeamStats", b =>
                {
                    b.Navigation("StatsTotal");
                });
#pragma warning restore 612, 618
        }
    }
}

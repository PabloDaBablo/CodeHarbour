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
    [Migration("20240222193811_GamePlayerClass")]
    partial class GamePlayerClass
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("GameLine_Up", b =>
                {
                    b.Property<int>("GamesID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Line_UpsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesID", "Line_UpsID");

                    b.HasIndex("Line_UpsID");

                    b.ToTable("GameLine_Up");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Coach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoachMemberID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CoachName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("CoachNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DivisionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CoachMemberID")
                        .IsUnique();

                    b.HasIndex("DivisionID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Division", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DivAge")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DivisionTeams")
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

                    b.Property<int>("AwayTeamID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("GameLocation")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("GameTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("HomeTeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AwayTeamID");

                    b.HasIndex("HomeTeamID");

                    b.HasIndex("ID", "HomeTeamID", "AwayTeamID", "GameDate", "GameTime", "GameLocation");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.GamePlayer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamLineup")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlayerID", "GameID")
                        .IsUnique();

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.ImportReport", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Club")
                        .HasColumnType("TEXT");

                    b.Property<string>("Division")
                        .HasColumnType("TEXT");

                    b.Property<string>("First_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Last_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Member_ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Season")
                        .HasColumnType("TEXT");

                    b.Property<string>("Team")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable((string)null);

                    b.ToView("Reports", (string)null);
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

                    b.Property<int?>("TeamID1")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TeamID1");

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

                    b.HasIndex("PlayerID");

                    b.ToTable("Line_Up_Players");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DivisionID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerFirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerLastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerMemberID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlayerNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("DivisionID");

                    b.HasIndex("PlayerMemberID")
                        .IsUnique();

                    b.HasIndex("TeamID");

                    b.HasIndex("PlayerNumber", "TeamID")
                        .IsUnique();

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

                    b.Property<int?>("CoachID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DivisionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CoachID");

                    b.HasIndex("DivisionID");

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

                    b.Property<int?>("ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoachID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("Team_Coaches");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team_Game", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHomeTeam")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("Team_Games");
                });

            modelBuilder.Entity("GameLine_Up", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Line_Up", null)
                        .WithMany()
                        .HasForeignKey("Line_UpsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Coach", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionID");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Division", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.League", "League")
                        .WithMany("Divisions")
                        .HasForeignKey("LeagueID");

                    b.Navigation("League");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Game", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Team", "AwayTeam")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Team", "HomeTeam")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.GamePlayer", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Player", "Player")
                        .WithMany("GamePlayers")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithMany("LineUp")
                        .HasForeignKey("TeamID1");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up_Player", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Line_Up", "Line_Up")
                        .WithMany("LineUps")
                        .HasForeignKey("Line_UpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Player", "Player")
                        .WithMany("LineUps")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line_Up");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Player", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionID");

                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Division");

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
                        .HasForeignKey("CoachID");

                    b.HasOne("WMBA_7_2_.Models.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionID");

                    b.Navigation("Coach");

                    b.Navigation("Division");
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

            modelBuilder.Entity("WMBA_7_2_.Models.Team_Game", b =>
                {
                    b.HasOne("WMBA_7_2_.Models.Game", "Game")
                        .WithMany("Team_Games")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMBA_7_2_.Models.Team", "Team")
                        .WithMany("Team_Games")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Coach", b =>
                {
                    b.Navigation("TeamCoach");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Game", b =>
                {
                    b.Navigation("Team_Games");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.League", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Line_Up", b =>
                {
                    b.Navigation("LineUps");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Player", b =>
                {
                    b.Navigation("GamePlayers");

                    b.Navigation("LineUps");

                    b.Navigation("StatsTotal");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.Team", b =>
                {
                    b.Navigation("AwayGames");

                    b.Navigation("HomeGames");

                    b.Navigation("LineUp");

                    b.Navigation("Players");

                    b.Navigation("StatsTotal");

                    b.Navigation("TeamCoaches");

                    b.Navigation("TeamStats");

                    b.Navigation("Team_Games");
                });

            modelBuilder.Entity("WMBA_7_2_.Models.TeamStats", b =>
                {
                    b.Navigation("StatsTotal");
                });
#pragma warning restore 612, 618
        }
    }
}

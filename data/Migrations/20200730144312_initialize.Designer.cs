﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace data.Migrations
{
    [DbContext(typeof(TeamContext))]
    [Migration("20200730144312_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Domain.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CurrentTeamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentTeamId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Domain.ManagerTeamHistory", b =>
                {
                    b.Property<Guid>("ManagerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("TEXT");

                    b.HasKey("ManagerId", "TeamId");

                    b.ToTable("ManagerTeamHistory");
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeStadium")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nickname")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearFounded")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Domain.Manager", b =>
                {
                    b.HasOne("Domain.Team", null)
                        .WithOne("_manager")
                        .HasForeignKey("Domain.Manager", "CurrentTeamId");

                    b.OwnsOne("SharedKernel.PersonFullName", "NameFactory", b1 =>
                        {
                            b1.Property<Guid>("CurrentTeamId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("First")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Last")
                                .HasColumnType("TEXT");

                            b1.HasKey("CurrentTeamId");

                            b1.ToTable("Managers");

                            b1.WithOwner()
                                .HasForeignKey("CurrentTeamId");
                        });
                });

            modelBuilder.Entity("Domain.ManagerTeamHistory", b =>
                {
                    b.HasOne("Domain.Manager", null)
                        .WithMany("PastTeams")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.OwnsOne("Domain.UniformColors", "HomeColors", b1 =>
                        {
                            b1.Property<Guid>("TeamId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Primary")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Secondary")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("TeamId");

                            b1.ToTable("Teams");

                            b1.WithOwner()
                                .HasForeignKey("TeamId");
                        });
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.HasOne("Domain.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.OwnsOne("SharedKernel.PersonFullName", "NameFactory", b1 =>
                        {
                            b1.Property<Guid>("PlayerId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("First")
                                .HasColumnName("FName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Last")
                                .HasColumnType("TEXT");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

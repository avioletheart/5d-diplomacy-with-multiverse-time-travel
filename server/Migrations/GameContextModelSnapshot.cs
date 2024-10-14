﻿// <auto-generated />
using System.Collections.Generic;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _5dDiplomacyWithMultiverseTimeTravel.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int[]>("ChildTimelines")
                        .IsRequired()
                        .HasColumnType("int[]");

                    b.Property<bool>("MightAdvance")
                        .HasColumnType("bool");

                    b.Property<int>("Phase")
                        .HasColumnType("int");

                    b.Property<int>("Timeline")
                        .HasColumnType("int");

                    b.Property<int>("WorldId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Entities.Centre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<int?>("Owner")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Location", "Entities.Centre.Location#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Centres");
                });

            modelBuilder.Entity("Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HasStrictAdjacencies")
                        .HasColumnType("bool");

                    b.Property<bool>("IsSandbox")
                        .HasColumnType("bool");

                    b.Property<int[]>("Players")
                        .IsRequired()
                        .HasColumnType("int[]");

                    b.Property<int[]>("PlayersSubmitted")
                        .IsRequired()
                        .HasColumnType("int[]");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("WorldId")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Location", "Entities.Order.Location#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("WorldId");

                    b.ToTable("Orders");

                    b.HasDiscriminator().HasValue("Order");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<bool>("MustRetreat")
                        .HasColumnType("bool");

                    b.Property<int>("Owner")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Location", "Entities.Unit.Location#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Entities.World", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Iteration")
                        .HasColumnType("int");

                    b.Property<int?>("Winner")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("Worlds");
                });

            modelBuilder.Entity("Entities.Build", b =>
                {
                    b.HasBaseType("Entities.Order");

                    b.HasDiscriminator().HasValue("Build");
                });

            modelBuilder.Entity("Entities.Convoy", b =>
                {
                    b.HasBaseType("Entities.Order");

                    b.ComplexProperty<Dictionary<string, object>>("Destination", "Entities.Convoy.Destination#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Midpoint", "Entities.Convoy.Midpoint#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");
                        });

                    b.HasDiscriminator().HasValue("Convoy");
                });

            modelBuilder.Entity("Entities.Disband", b =>
                {
                    b.HasBaseType("Entities.Order");

                    b.HasDiscriminator().HasValue("Disband");
                });

            modelBuilder.Entity("Entities.Hold", b =>
                {
                    b.HasBaseType("Entities.Order");

                    b.HasDiscriminator().HasValue("Hold");
                });

            modelBuilder.Entity("Entities.Move", b =>
                {
                    b.HasBaseType("Entities.Order");

                    b.ComplexProperty<Dictionary<string, object>>("Destination", "Entities.Move.Destination#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");
                        });

                    b.HasDiscriminator().HasValue("Move");
                });

            modelBuilder.Entity("Entities.Support", b =>
                {
                    b.HasBaseType("Entities.Order");

                    b.ComplexProperty<Dictionary<string, object>>("Destination", "Entities.Support.Destination#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Midpoint", "Entities.Support.Midpoint#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Phase")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<string>("RegionId")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.Property<int>("Timeline")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("int");
                        });

                    b.HasDiscriminator().HasValue("Support");
                });

            modelBuilder.Entity("Entities.Board", b =>
                {
                    b.HasOne("Entities.World", "World")
                        .WithMany("Boards")
                        .HasForeignKey("WorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("World");
                });

            modelBuilder.Entity("Entities.Centre", b =>
                {
                    b.HasOne("Entities.Board", "Board")
                        .WithMany("Centres")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.HasOne("Entities.Unit", "Unit")
                        .WithMany("Orders")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Entities.World", "World")
                        .WithMany("Orders")
                        .HasForeignKey("WorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");

                    b.Navigation("World");
                });

            modelBuilder.Entity("Entities.Unit", b =>
                {
                    b.HasOne("Entities.Board", "Board")
                        .WithMany("Units")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Entities.World", b =>
                {
                    b.HasOne("Entities.Game", "Game")
                        .WithOne("World")
                        .HasForeignKey("Entities.World", "GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Entities.Board", b =>
                {
                    b.Navigation("Centres");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Entities.Game", b =>
                {
                    b.Navigation("World");
                });

            modelBuilder.Entity("Entities.Unit", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Entities.World", b =>
                {
                    b.Navigation("Boards");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleAPIwithJwt.Context.Implenetation;

namespace SampleAPIwithJwt.Migrations
{
    [DbContext(typeof(AppDataBaseContext))]
    partial class AppDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("SampleAPIwithJwt.Entities.Figure.FigureEntityModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FigureName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Heigh")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SideOne")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("SideTwo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FigureName");

                    b.ToTable("Figures");
                });

            modelBuilder.Entity("SampleAPIwithJwt.Entities.User.UserEntityModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Id", "Password")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1692909-24ef-4564-862d-94a146bc885b"),
                            Login = "Admin",
                            Password = "123"
                        },
                        new
                        {
                            Id = new Guid("158a8ce5-903a-4a56-9a43-2445128b7949"),
                            Login = "User1",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("SampleAPIwithJwt.Entities.UserPermission.UserPermissionEntityModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PermitsName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Permits");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bdad0bef-d83e-4dd8-b1fe-37fa8ded02d5"),
                            PermitsName = "Users.Read",
                            UserId = new Guid("c1692909-24ef-4564-862d-94a146bc885b")
                        },
                        new
                        {
                            Id = new Guid("6abc8cb9-6928-4052-8c5b-070cf54f80ac"),
                            PermitsName = "Users.Write",
                            UserId = new Guid("c1692909-24ef-4564-862d-94a146bc885b")
                        },
                        new
                        {
                            Id = new Guid("d3a5d315-2a04-43b6-afc0-039bf45f0234"),
                            PermitsName = "Users.Update",
                            UserId = new Guid("c1692909-24ef-4564-862d-94a146bc885b")
                        },
                        new
                        {
                            Id = new Guid("edcb1e7f-6e9e-4f31-8b26-84f1fc0a2107"),
                            PermitsName = "User.Delete",
                            UserId = new Guid("c1692909-24ef-4564-862d-94a146bc885b")
                        });
                });

            modelBuilder.Entity("SampleAPIwithJwt.Entities.UserPermission.UserPermissionEntityModel", b =>
                {
                    b.HasOne("SampleAPIwithJwt.Entities.User.UserEntityModel", "User")
                        .WithMany("Permits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleAPIwithJwt.Entities.User.UserEntityModel", b =>
                {
                    b.Navigation("Permits");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTNP.EFCore.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NTNP.API.Migrations
{
    [DbContext(typeof(NTNPContext))]
    partial class NTNPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NTNP.EFCore.Models.ApplicationParameters.ApplicationParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParameterValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ApplicationParameter", (string)null);
                });

            modelBuilder.Entity("NTNP.EFCore.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "nhatmytasdu@gmail",
                            Name = "nhat"
                        },
                        new
                        {
                            Id = 2,
                            Email = "asd@gmail",
                            Name = "nhu"
                        });
                });

            modelBuilder.Entity("NTNP.EFCore.Models.Vocabularies.Vocabulary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<string>("Transcript")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("transcript");

                    b.HasKey("Id");

                    b.ToTable("Vocabulary", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "this is a comment",
                            CreatedAt = new DateTime(2023, 3, 1, 16, 11, 46, 374, DateTimeKind.Utc).AddTicks(2035),
                            Deleted = false,
                            Name = "hello",
                            Path = "",
                            Transcript = "xin chao"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "this is a comment",
                            CreatedAt = new DateTime(2023, 3, 1, 16, 11, 46, 374, DateTimeKind.Utc).AddTicks(2037),
                            Deleted = false,
                            Name = "what",
                            Path = "",
                            Transcript = "cai gi"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

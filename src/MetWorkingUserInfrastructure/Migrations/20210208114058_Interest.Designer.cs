﻿// <auto-generated />
using System;
using MetWorkingUserInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MetWorkingUserInfrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210208114058_Interest")]
    partial class Interest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MetWorkingUserDomain.Entities.Interest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("MetWorkingUserDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

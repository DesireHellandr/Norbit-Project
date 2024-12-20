﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Norbit_Project.Data;

#nullable disable

namespace Norbit_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241220063818_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Norbit_Project.Models.Body", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SchematicImg")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("bodies");
                });

            modelBuilder.Entity("Norbit_Project.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Norbit_Project.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DateAudit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("PinoutImg")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PlaceId");

                    b.ToTable("components");
                });

            modelBuilder.Entity("Norbit_Project.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("places");
                });

            modelBuilder.Entity("Norbit_Project.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Norbit_Project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Norbit_Project.Models.Component", b =>
                {
                    b.HasOne("Norbit_Project.Models.Body", null)
                        .WithMany()
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Norbit_Project.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Norbit_Project.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Norbit_Project.Models.User", b =>
                {
                    b.HasOne("Norbit_Project.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Norbit_Project.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

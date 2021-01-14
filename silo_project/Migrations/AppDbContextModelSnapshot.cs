﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using silo_project.Models;

namespace silo_project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("silo_project.Models.DeviceRef", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DeviceRefs");
                });

            modelBuilder.Entity("silo_project.Models.Record", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SiloID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SiloID");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("silo_project.Models.Setting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("BoolValue")
                        .HasColumnType("bit");

                    b.Property<int>("IntValue")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StrValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("silo_project.Models.Silo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AllowDownload")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CommandID")
                        .HasColumnType("int");

                    b.Property<int?>("DeviceIDID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ScaleValue")
                        .HasColumnType("Decimal(8,3)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<int>("ZeroValue")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DeviceIDID");

                    b.ToTable("Silos");
                });

            modelBuilder.Entity("silo_project.Models.Record", b =>
                {
                    b.HasOne("silo_project.Models.Silo", "Silo")
                        .WithMany()
                        .HasForeignKey("SiloID");

                    b.Navigation("Silo");
                });

            modelBuilder.Entity("silo_project.Models.Silo", b =>
                {
                    b.HasOne("silo_project.Models.DeviceRef", "DeviceID")
                        .WithMany()
                        .HasForeignKey("DeviceIDID");

                    b.Navigation("DeviceID");
                });
#pragma warning restore 612, 618
        }
    }
}
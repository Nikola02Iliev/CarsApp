﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPICars.Context;

#nullable disable

namespace WebAPICars.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241011145538_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPICars.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WebAPICars.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("WebAPICars.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("WebAPICars.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceId");

                    b.HasIndex("CarId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebAPICars.Models.Car", b =>
                {
                    b.HasOne("WebAPICars.Models.Manufacturer", "Manufacturer")
                        .WithMany("Cars")
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("WebAPICars.Models.Owner", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Manufacturer");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WebAPICars.Models.Service", b =>
                {
                    b.HasOne("WebAPICars.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("WebAPICars.Models.Manufacturer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebAPICars.Models.Owner", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OASIS.Data;

namespace OASIS.Data.OASISMigrations
{
    [DbContext(typeof(OasisContext))]
    partial class OasisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("OA")
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("OASIS.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLineOne")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("AddressLineTwo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Phone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OASIS.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLineOne")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLineTwo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<long>("Phone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
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
                .HasAnnotation("ProductVersion", "3.1.12");

            modelBuilder.Entity("OASIS.Models.Approval", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BidID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<int>("DesignerStatusID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BidID")
                        .IsUnique();

                    b.HasIndex("ClientStatusID");

                    b.HasIndex("DesignerStatusID");

                    b.ToTable("Approvals");
                });

            modelBuilder.Entity("OASIS.Models.ApprovalStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApprovalID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ApprovalID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ApprovalStatuses");
                });

            modelBuilder.Entity("OASIS.Models.Bid", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BidStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("DesignerID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("EstAmount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("EstBidEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EstBidStartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ProjectEndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ProjectStartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SalesAsscociateID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comments")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("BidStatusID");

                    b.HasIndex("DesignerID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("SalesAsscociateID");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("OASIS.Models.BidLabour", b =>
                {
                    b.Property<int>("BidID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<double>("Hours")
                        .HasColumnType("REAL");

                    b.HasKey("BidID", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("BidLabours");
                });

            modelBuilder.Entity("OASIS.Models.BidProduct", b =>
                {
                    b.Property<int>("BidID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("BidID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("BidProducts");
                });

            modelBuilder.Entity("OASIS.Models.BidStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BidStatuses");
                });

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

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

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

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

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

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

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

                    b.Property<int>("RoleID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OASIS.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(8);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(15);

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OASIS.Models.ProductType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("OASIS.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("SiteAddressLineOne")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("SiteAddressLineTwo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("OASIS.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LabourCostPerHr")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LabourPricePerHr")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OASIS.Models.Approval", b =>
                {
                    b.HasOne("OASIS.Models.Bid", "Bid")
                        .WithOne("Approval")
                        .HasForeignKey("OASIS.Models.Approval", "BidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OASIS.Models.ApprovalStatus", "ClientStatus")
                        .WithMany()
                        .HasForeignKey("ClientStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OASIS.Models.ApprovalStatus", "DesignerStatus")
                        .WithMany()
                        .HasForeignKey("DesignerStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OASIS.Models.ApprovalStatus", b =>
                {
                    b.HasOne("OASIS.Models.Approval", null)
                        .WithMany("ApprovalStatuses")
                        .HasForeignKey("ApprovalID");
                });

            modelBuilder.Entity("OASIS.Models.Bid", b =>
                {
                    b.HasOne("OASIS.Models.BidStatus", "BidStatus")
                        .WithMany("Bids")
                        .HasForeignKey("BidStatusID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OASIS.Models.Employee", "Designer")
                        .WithMany()
                        .HasForeignKey("DesignerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OASIS.Models.Project", "project")
                        .WithMany("Bids")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OASIS.Models.Employee", "SalesAsscociate")
                        .WithMany()
                        .HasForeignKey("SalesAsscociateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OASIS.Models.BidLabour", b =>
                {
                    b.HasOne("OASIS.Models.Bid", "Bid")
                        .WithMany("BidLabours")
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OASIS.Models.Role", "Role")
                        .WithMany("BidLabours")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("OASIS.Models.BidProduct", b =>
                {
                    b.HasOne("OASIS.Models.Bid", "Bid")
                        .WithMany("BidProducts")
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OASIS.Models.Product", "Product")
                        .WithMany("BidProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("OASIS.Models.Employee", b =>
                {
                    b.HasOne("OASIS.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("OASIS.Models.Product", b =>
                {
                    b.HasOne("OASIS.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("OASIS.Models.Project", b =>
                {
                    b.HasOne("OASIS.Models.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

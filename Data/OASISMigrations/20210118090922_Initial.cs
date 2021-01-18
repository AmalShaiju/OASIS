﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OASIS.Data.OASISMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OA");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrgName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLineOne = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLineTwo = table.Column<string>(maxLength: 100, nullable: true),
                    ApartmentNumber = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Province = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    LabourCostPerHr = table.Column<decimal>(nullable: false),
                    LabourPricePerHr = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });
                migrationBuilder.Sql(
                  @"
                    CREATE TRIGGER SetRoleTimestampOnUpdate
                    AFTER UPDATE ON Roles
                    BEGIN
                        UPDATE Roles
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
                migrationBuilder.Sql(
                   @"
                    CREATE TRIGGER SetRoleTimestampOnInsert
                    AFTER INSERT ON Roles
                    BEGIN
                        UPDATE Roles
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                   END
               ");

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLineOne = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLineTwo = table.Column<string>(maxLength: 100, nullable: true),
                    ApartmentNumber = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Province = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "OA",
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                schema: "OA",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                schema: "OA",
                table: "Roles",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "OA");
        }
    }
}
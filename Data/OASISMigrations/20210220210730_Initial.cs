using System;
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
                name: "BidStatuses",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
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
                name: "ProductTypes",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "Projects",
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
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    SiteAddressLineOne = table.Column<string>(maxLength: 50, nullable: false),
                    SiteAddressLineTwo = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Province = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "OA",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    size = table.Column<string>(maxLength: 15, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalSchema: "OA",
                        principalTable: "ProductTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
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

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EstAmount = table.Column<double>(type: "decimal(9,2)", nullable: false),
                    ProjectStartDate = table.Column<DateTime>(nullable: true),
                    ProjectEndDate = table.Column<DateTime>(nullable: true),
                    EstBidStartDate = table.Column<DateTime>(nullable: false),
                    EstBidEndDate = table.Column<DateTime>(nullable: false),
                    comments = table.Column<string>(nullable: true),
                    DesignerID = table.Column<int>(nullable: false),
                    SalesAsscociateID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    BidStatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_BidStatuses_BidStatusID",
                        column: x => x.BidStatusID,
                        principalSchema: "OA",
                        principalTable: "BidStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Employees_DesignerID",
                        column: x => x.DesignerID,
                        principalSchema: "OA",
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "OA",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Employees_SalesAsscociateID",
                        column: x => x.SalesAsscociateID,
                        principalSchema: "OA",
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidLabours",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    BidID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidLabours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BidLabours_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "OA",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidLabours_Roles_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "OA",
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidProducts",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(nullable: false),
                    BidID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BidProducts_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "OA",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "OA",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalStatuses",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    ApprovalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Approvals",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comments = table.Column<string>(nullable: true),
                    ClientStatusID = table.Column<int>(nullable: false),
                    DesignerStatusID = table.Column<int>(nullable: false),
                    BidID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Approvals_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "OA",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Approvals_ApprovalStatuses_ClientStatusID",
                        column: x => x.ClientStatusID,
                        principalSchema: "OA",
                        principalTable: "ApprovalStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Approvals_ApprovalStatuses_DesignerStatusID",
                        column: x => x.DesignerStatusID,
                        principalSchema: "OA",
                        principalTable: "ApprovalStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_BidID",
                schema: "OA",
                table: "Approvals",
                column: "BidID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ClientStatusID",
                schema: "OA",
                table: "Approvals",
                column: "ClientStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_DesignerStatusID",
                schema: "OA",
                table: "Approvals",
                column: "DesignerStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStatuses_ApprovalID",
                schema: "OA",
                table: "ApprovalStatuses",
                column: "ApprovalID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStatuses_Name",
                schema: "OA",
                table: "ApprovalStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BidLabours_BidID",
                schema: "OA",
                table: "BidLabours",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_BidLabours_RoleID",
                schema: "OA",
                table: "BidLabours",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_BidProducts_BidID",
                schema: "OA",
                table: "BidProducts",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_BidProducts_ProductID",
                schema: "OA",
                table: "BidProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidStatusID",
                schema: "OA",
                table: "Bids",
                column: "BidStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_DesignerID",
                schema: "OA",
                table: "Bids",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectID",
                schema: "OA",
                table: "Bids",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_SalesAsscociateID",
                schema: "OA",
                table: "Bids",
                column: "SalesAsscociateID");

            migrationBuilder.CreateIndex(
                name: "IX_BidStatuses_Name",
                schema: "OA",
                table: "BidStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                schema: "OA",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                schema: "OA",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                schema: "OA",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                schema: "OA",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeID",
                schema: "OA",
                table: "Products",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Name",
                schema: "OA",
                table: "ProductTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerID",
                schema: "OA",
                table: "Projects",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                schema: "OA",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                schema: "OA",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalStatuses_Approvals_ApprovalID",
                schema: "OA",
                table: "ApprovalStatuses",
                column: "ApprovalID",
                principalSchema: "OA",
                principalTable: "Approvals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Bids_BidID",
                schema: "OA",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovalStatuses_ClientStatusID",
                schema: "OA",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovalStatuses_DesignerStatusID",
                schema: "OA",
                table: "Approvals");

            migrationBuilder.DropTable(
                name: "BidLabours",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "BidProducts",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "BidStatuses",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "ApprovalStatuses",
                schema: "OA");

            migrationBuilder.DropTable(
                name: "Approvals",
                schema: "OA");
        }
    }
}

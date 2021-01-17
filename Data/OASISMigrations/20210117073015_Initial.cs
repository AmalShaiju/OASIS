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
                name: "Role",
                schema: "OA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    LabourCostPerHr = table.Column<decimal>(nullable: false),
                    LabourPricePerHr = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

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
                        name: "FK_Employees_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "OA",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                schema: "OA",
                table: "Employees",
                column: "RoleID");
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
                name: "Role",
                schema: "OA");
        }
    }
}

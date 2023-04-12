using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentNet104.Migrations
{
    public partial class AssNet104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    IdMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.IdMaterial);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    IdPosition = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.IdPosition);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    IdProducer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.IdProducer);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    IdStore = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.IdStore);
                });

            migrationBuilder.CreateTable(
                name: "MaterialDetails",
                columns: table => new
                {
                    IdMDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IdProducer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialDetails", x => x.IdMDetail);
                    table.ForeignKey(
                        name: "FK_Nsx",
                        column: x => x.IdProducer,
                        principalTable: "Producers",
                        principalColumn: "IdProducer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SP2",
                        column: x => x.IdMaterial,
                        principalTable: "Materials",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    IdStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdPosition = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStore = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.IdStaff);
                    table.ForeignKey(
                        name: "FK_CH",
                        column: x => x.IdStore,
                        principalTable: "Stores",
                        principalColumn: "IdStore",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV",
                        column: x => x.IdPosition,
                        principalTable: "Positions",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PointsUsed = table.Column<int>(type: "int", nullable: false),
                    IdCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.IdBill);
                    table.ForeignKey(
                        name: "FK_KH",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NV",
                        column: x => x.IdStaff,
                        principalTable: "Staffs",
                        principalColumn: "IdStaff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "billDetailss",
                columns: table => new
                {
                    IdMDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billDetailss", x => x.IdMDetail);
                    table.ForeignKey(
                        name: "FK_HD",
                        column: x => x.IdBill,
                        principalTable: "bills",
                        principalColumn: "IdBill",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SP",
                        column: x => x.IdMaterial,
                        principalTable: "Materials",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billDetailss_IdBill",
                table: "billDetailss",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_billDetailss_IdMaterial",
                table: "billDetailss",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_bills_IdCustomer",
                table: "bills",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_bills_IdStaff",
                table: "bills",
                column: "IdStaff");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_IdMaterial",
                table: "MaterialDetails",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_IdProducer",
                table: "MaterialDetails",
                column: "IdProducer");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_IdPosition",
                table: "Staffs",
                column: "IdPosition");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_IdStore",
                table: "Staffs",
                column: "IdStore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "billDetailss");

            migrationBuilder.DropTable(
                name: "MaterialDetails");

            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}

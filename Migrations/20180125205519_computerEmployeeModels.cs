using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BangazonAPI.Migrations
{
    public partial class computerEmployeeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    ComputerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DecommissionDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "ComputerEmployee",
                columns: table => new
                {
                    ComputerEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerId = table.Column<int>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerEmployee", x => x.ComputerEmployeeId);
                    table.ForeignKey(
                        name: "FK_ComputerEmployee_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEmployee_ComputerId",
                table: "ComputerEmployee",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEmployee_EmployeeId",
                table: "ComputerEmployee",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerEmployee");

            migrationBuilder.DropTable(
                name: "Computer");
        }
    }
}

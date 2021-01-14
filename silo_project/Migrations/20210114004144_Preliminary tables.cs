using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace silo_project.Migrations
{
    public partial class Preliminarytables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceRefs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRefs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BoolValue = table.Column<bool>(type: "bit", nullable: false),
                    IntValue = table.Column<int>(type: "int", nullable: false),
                    StrValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    DeviceIDID = table.Column<int>(type: "int", nullable: true),
                    CommandID = table.Column<int>(type: "int", nullable: false),
                    ZeroValue = table.Column<int>(type: "int", nullable: false),
                    ScaleValue = table.Column<decimal>(type: "Decimal(8,3)", nullable: false),
                    AllowDownload = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Silos_DeviceRefs_DeviceIDID",
                        column: x => x.DeviceIDID,
                        principalTable: "DeviceRefs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiloID = table.Column<int>(type: "int", nullable: true),
                    EnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Records_Silos_SiloID",
                        column: x => x.SiloID,
                        principalTable: "Silos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_SiloID",
                table: "Records",
                column: "SiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_DeviceIDID",
                table: "Silos",
                column: "DeviceIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Silos");

            migrationBuilder.DropTable(
                name: "DeviceRefs");
        }
    }
}

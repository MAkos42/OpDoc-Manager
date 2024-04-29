using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forklifts",
                columns: table => new
                {
                    UniqueId = table.Column<string>(type: "text", nullable: false),
                    General_Name = table.Column<string>(type: "text", nullable: false),
                    General_Manufacturer = table.Column<string>(type: "text", nullable: false),
                    General_Type = table.Column<string>(type: "text", nullable: false),
                    General_ControlMethod = table.Column<int>(type: "integer", nullable: false),
                    General_ManufacturingYear = table.Column<int>(type: "integer", nullable: false),
                    General_ProductionNumber = table.Column<string>(type: "text", nullable: false),
                    General_ForkliftType = table.Column<int>(type: "integer", nullable: false),
                    General_EnergySource = table.Column<int>(type: "integer", nullable: false),
                    General_EntryIntoService = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forklifts", x => x.UniqueId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forklifts");
        }
    }
}

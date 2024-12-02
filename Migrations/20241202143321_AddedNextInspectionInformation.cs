using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddedNextInspectionInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "NextInspectionDate",
                table: "PeriodicInspectionInformation",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "NextInspectionOpHours",
                table: "PeriodicInspectionInformation",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextInspectionDate",
                table: "PeriodicInspectionInformation");

            migrationBuilder.DropColumn(
                name: "NextInspectionOpHours",
                table: "PeriodicInspectionInformation");
        }
    }
}

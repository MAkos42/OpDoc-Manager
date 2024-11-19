using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class RemovedMSZ9750Signature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MSZ9750SignDate",
                table: "PeriodicInspectionInformation");

            migrationBuilder.DropColumn(
                name: "MSZ9750SigneeName",
                table: "PeriodicInspectionInformation");

            migrationBuilder.DropColumn(
                name: "MSZ9750SigneePosition",
                table: "PeriodicInspectionInformation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "MSZ9750SignDate",
                table: "PeriodicInspectionInformation",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "MSZ9750SigneeName",
                table: "PeriodicInspectionInformation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MSZ9750SigneePosition",
                table: "PeriodicInspectionInformation",
                type: "text",
                nullable: true);
        }
    }
}

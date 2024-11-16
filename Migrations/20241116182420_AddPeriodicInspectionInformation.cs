using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodicInspectionInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodicInspectionInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperatingHours = table.Column<int>(type: "integer", nullable: false),
                    LastInspectionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InspectionCategory = table.Column<string>(type: "text", nullable: false),
                    ManufacturerInspectionId = table.Column<string>(type: "text", nullable: true),
                    OperatorInspectionId = table.Column<string>(type: "text", nullable: true),
                    MSZ9750InspectionGroupId = table.Column<int>(type: "integer", nullable: true),
                    MSZ9750SignDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MSZ9750SigneeName = table.Column<string>(type: "text", nullable: true),
                    MSZ9750SigneePosition = table.Column<string>(type: "text", nullable: true),
                    StructuralInspectionOpHours = table.Column<int>(type: "integer", nullable: false),
                    StructuralInspectionMonths = table.Column<int>(type: "integer", nullable: false),
                    MainInspectionPeriodOpHours = table.Column<int>(type: "integer", nullable: false),
                    MainInspectionPeriodMonths = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicInspectionInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicInspectionInformation_Forklifts_Id",
                        column: x => x.Id,
                        principalTable: "Forklifts",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomInspectionPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ForkliftId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ManufacturerOperatingHours = table.Column<int>(type: "integer", nullable: false),
                    CheckInspectionPeriod = table.Column<int>(type: "integer", nullable: true),
                    CheckInspectionType = table.Column<string>(type: "text", nullable: true),
                    StructuralInspectionPeriod = table.Column<int>(type: "integer", nullable: false),
                    StructuralInspectionType = table.Column<string>(type: "text", nullable: false),
                    MainInspectionPeriod = table.Column<int>(type: "integer", nullable: false),
                    MainInspectionType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInspectionPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomInspectionPeriods_PeriodicInspectionInformation_Forkl~",
                        column: x => x.ForkliftId,
                        principalTable: "PeriodicInspectionInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "periodicInspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ForkliftId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    RequiredOperationHours = table.Column<int>(type: "integer", nullable: false),
                    CurrentOperatingHours = table.Column<int>(type: "integer", nullable: false),
                    RequiredInspectionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InspectionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InspectionReportId = table.Column<string>(type: "text", nullable: false),
                    HasPassedInspection = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodicInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_periodicInspections_PeriodicInspectionInformation_ForkliftId",
                        column: x => x.ForkliftId,
                        principalTable: "PeriodicInspectionInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomInspectionPeriods_ForkliftId",
                table: "CustomInspectionPeriods",
                column: "ForkliftId");

            migrationBuilder.CreateIndex(
                name: "IX_periodicInspections_ForkliftId",
                table: "periodicInspections",
                column: "ForkliftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomInspectionPeriods");

            migrationBuilder.DropTable(
                name: "periodicInspections");

            migrationBuilder.DropTable(
                name: "PeriodicInspectionInformation");
        }
    }
}

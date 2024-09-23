using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forklifts",
                columns: table => new
                {
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ManufacturingYear = table.Column<int>(type: "integer", nullable: false),
                    ProductionNumber = table.Column<string>(type: "text", nullable: false),
                    EntryIntoService = table.Column<DateOnly>(type: "date", nullable: false),
                    ForkliftType = table.Column<string>(type: "text", nullable: false),
                    ControlMethod = table.Column<string>(type: "text", nullable: false),
                    EnergySource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forklifts", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "OperatorInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    OwnerAddress = table.Column<string>(type: "text", nullable: false),
                    IsDifferentOperator = table.Column<bool>(type: "boolean", nullable: false),
                    Operator = table.Column<string>(type: "text", nullable: true),
                    OperatorAddress = table.Column<string>(type: "text", nullable: true),
                    TransferDate = table.Column<DateOnly>(type: "date", nullable: true),
                    TransferID = table.Column<string>(type: "text", nullable: true),
                    OperationLocation = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    UserPosition = table.Column<string>(type: "text", nullable: false),
                    TechnicianName = table.Column<string>(type: "text", nullable: false),
                    TechnicianPosition = table.Column<string>(type: "text", nullable: false),
                    ForkliftAdministrator = table.Column<string>(type: "text", nullable: true),
                    ForkliftAdminPosition = table.Column<string>(type: "text", nullable: true),
                    ForkliftAdminContact = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatorInformation_Forklifts_Id",
                        column: x => x.Id,
                        principalTable: "Forklifts",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatorInformation");

            migrationBuilder.DropTable(
                name: "Forklifts");
        }
    }
}

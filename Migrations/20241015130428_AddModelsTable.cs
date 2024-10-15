using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Technical",
                table: "Forklifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ForkliftModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    LoadCapacity = table.Column<int>(type: "integer", nullable: false),
                    NominalLiftHeight = table.Column<int>(type: "integer", nullable: false),
                    MaximumLiftHeight = table.Column<int>(type: "integer", nullable: false),
                    MaximumHeightLoadCapacity = table.Column<int>(type: "integer", nullable: false),
                    LoadedTraversalSpeed = table.Column<double>(type: "double precision", nullable: false),
                    UnloadedTraversalSpeed = table.Column<double>(type: "double precision", nullable: false),
                    ForwardTiltAngle = table.Column<double>(type: "double precision", nullable: false),
                    BackwardTiltAngle = table.Column<double>(type: "double precision", nullable: false),
                    FreeLiftHeight = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    TransportHeight = table.Column<int>(type: "integer", nullable: false),
                    MaximumTransportHeight = table.Column<int>(type: "integer", nullable: false),
                    MaximumOperationalHeight = table.Column<int>(type: "integer", nullable: false),
                    OuterTurningCircle = table.Column<int>(type: "integer", nullable: false),
                    InnerTurningCircle = table.Column<int>(type: "integer", nullable: false),
                    AxleWidth = table.Column<int>(type: "integer", nullable: false),
                    FrontWheelspan = table.Column<int>(type: "integer", nullable: false),
                    BackWheelspan = table.Column<int>(type: "integer", nullable: false),
                    RideHeight = table.Column<int>(type: "integer", nullable: false),
                    LoadedTopSpeed = table.Column<int>(type: "integer", nullable: false),
                    UnloadedTopSpeed = table.Column<int>(type: "integer", nullable: false),
                    TractiveForce = table.Column<int>(type: "integer", nullable: false),
                    FrontWheelCount = table.Column<int>(type: "integer", nullable: false),
                    BackWheelCount = table.Column<int>(type: "integer", nullable: false),
                    FrontWheelSize = table.Column<int>(type: "integer", nullable: false),
                    BackWheelSize = table.Column<int>(type: "integer", nullable: false),
                    FrontWheelPressure = table.Column<int>(type: "integer", nullable: false),
                    BackWheelPressure = table.Column<int>(type: "integer", nullable: false),
                    OperationalWeight = table.Column<int>(type: "integer", nullable: false),
                    BatteryWeight = table.Column<int>(type: "integer", nullable: false),
                    BreakingForce = table.Column<int>(type: "integer", nullable: false),
                    ParkingBreakForce = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForkliftModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_ForkliftModels_Id",
                        column: x => x.Id,
                        principalTable: "ForkliftModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BatteryType = table.Column<string>(type: "text", nullable: false),
                    BatteryManufacturer = table.Column<string>(type: "text", nullable: false),
                    NominalBatteryCapacity = table.Column<int>(type: "integer", nullable: false),
                    BatteryVoltage = table.Column<int>(type: "integer", nullable: false),
                    BatteryCellCount = table.Column<int>(type: "integer", nullable: false),
                    EngineManufacturer = table.Column<string>(type: "text", nullable: false),
                    EngineOutput = table.Column<int>(type: "integer", nullable: false),
                    EngineRPM = table.Column<int>(type: "integer", nullable: false),
                    InverterManufacturer = table.Column<string>(type: "text", nullable: false),
                    InverterType = table.Column<string>(type: "text", nullable: false),
                    InverterPerformance = table.Column<int>(type: "integer", nullable: false),
                    FrequencyConverterManufacturer = table.Column<string>(type: "text", nullable: false),
                    FrequencyConverterType = table.Column<string>(type: "text", nullable: false),
                    FrequencyConverterPerformance = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricEngines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricEngines_Engines_Id",
                        column: x => x.Id,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICEngine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProductionNumber = table.Column<string>(type: "text", nullable: false),
                    EngineOutput = table.Column<int>(type: "integer", nullable: false),
                    CylinderVolume = table.Column<int>(type: "integer", nullable: false),
                    EnviromentalClassification = table.Column<string>(type: "text", nullable: true),
                    CatalyticConverter = table.Column<string>(type: "text", nullable: true),
                    FuelCapacity = table.Column<int>(type: "integer", nullable: false),
                    NatGasSafetyValveType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICEngine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICEngine_Engines_Id",
                        column: x => x.Id,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForkliftModels_Manufacturer_Model",
                table: "ForkliftModels",
                columns: new[] { "Manufacturer", "Model" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricEngines");

            migrationBuilder.DropTable(
                name: "ICEngine");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "ForkliftModels");

            migrationBuilder.DropColumn(
                name: "Technical",
                table: "Forklifts");
        }
    }
}

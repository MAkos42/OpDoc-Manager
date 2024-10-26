using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddModelInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
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
                    EngineOutput = table.Column<double>(type: "double precision", nullable: false),
                    EngineRPM = table.Column<int>(type: "integer", nullable: false),
                    InverterManufacturer = table.Column<string>(type: "text", nullable: false),
                    InverterType = table.Column<string>(type: "text", nullable: false),
                    InverterPerformance = table.Column<string>(type: "text", nullable: false),
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
                name: "ForkliftModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    LoadCapacity = table.Column<double>(type: "double precision", nullable: false),
                    FreeLift = table.Column<int>(type: "integer", nullable: false),
                    NominalLiftHeight = table.Column<int>(type: "integer", nullable: false),
                    MaxLiftHeight = table.Column<int>(type: "integer", nullable: false),
                    MaxHeightMaxLoad = table.Column<double>(type: "double precision", nullable: false),
                    LiftSpeedUnloaded = table.Column<double>(type: "double precision", nullable: false),
                    LiftSpeedLoaded = table.Column<double>(type: "double precision", nullable: false),
                    MastForwardTiltAngle = table.Column<double>(type: "double precision", nullable: false),
                    MastBackwardTiltAngle = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    HeightTransportPosition = table.Column<int>(type: "integer", nullable: false),
                    HeightMastLowered = table.Column<int>(type: "integer", nullable: false),
                    HeightMastRaised = table.Column<int>(type: "integer", nullable: false),
                    OuterTurningCircle = table.Column<int>(type: "integer", nullable: false),
                    InnerTurningCircle = table.Column<int>(type: "integer", nullable: false),
                    Wheelbase = table.Column<int>(type: "integer", nullable: false),
                    TrackWidthFront = table.Column<int>(type: "integer", nullable: false),
                    TrackWidthBack = table.Column<int>(type: "integer", nullable: false),
                    GroundClearance = table.Column<int>(type: "integer", nullable: false),
                    TopSpeedWithLoad = table.Column<double>(type: "double precision", nullable: false),
                    TopSpeedWithoutLoad = table.Column<double>(type: "double precision", nullable: false),
                    DrawbarPull = table.Column<int>(type: "integer", nullable: false),
                    FrontWheelCount = table.Column<int>(type: "integer", nullable: false),
                    BackWheelCount = table.Column<int>(type: "integer", nullable: false),
                    FrontWheelSize = table.Column<string>(type: "text", nullable: false),
                    BackWheelSize = table.Column<string>(type: "text", nullable: false),
                    FrontWheelPressure = table.Column<double>(type: "double precision", nullable: false),
                    BackWheelPressure = table.Column<double>(type: "double precision", nullable: false),
                    OperationalWeight = table.Column<int>(type: "integer", nullable: false),
                    BatteryWeight = table.Column<int>(type: "integer", nullable: false),
                    BreakingForce = table.Column<int>(type: "integer", nullable: false),
                    ParkingBreakForce = table.Column<int>(type: "integer", nullable: false),
                    EngineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForkliftModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForkliftModels_Engines_EngineId",
                        column: x => x.EngineId,
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
                    RatedOutput = table.Column<double>(type: "double precision", nullable: false),
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
                name: "IX_ForkliftModels_EngineId",
                table: "ForkliftModels",
                column: "EngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForkliftModels_Manufacturer_Type",
                table: "ForkliftModels",
                columns: new[] { "Manufacturer", "Type" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricEngines");

            migrationBuilder.DropTable(
                name: "ForkliftModels");

            migrationBuilder.DropTable(
                name: "ICEngine");

            migrationBuilder.DropTable(
                name: "Engines");
        }
    }
}

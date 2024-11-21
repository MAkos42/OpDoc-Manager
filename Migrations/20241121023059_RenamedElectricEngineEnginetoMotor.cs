using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class RenamedElectricEngineEnginetoMotor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EngineRPM",
                table: "ElectricEngines",
                newName: "MotorRPM");

            migrationBuilder.RenameColumn(
                name: "EngineOutput",
                table: "ElectricEngines",
                newName: "MotorOutput");

            migrationBuilder.RenameColumn(
                name: "EngineManufacturer",
                table: "ElectricEngines",
                newName: "MotorManufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotorRPM",
                table: "ElectricEngines",
                newName: "EngineRPM");

            migrationBuilder.RenameColumn(
                name: "MotorOutput",
                table: "ElectricEngines",
                newName: "EngineOutput");

            migrationBuilder.RenameColumn(
                name: "MotorManufacturer",
                table: "ElectricEngines",
                newName: "EngineManufacturer");
        }
    }
}

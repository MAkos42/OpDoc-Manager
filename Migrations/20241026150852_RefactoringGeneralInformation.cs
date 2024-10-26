using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringGeneralInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalInformation");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "ForkliftType",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "OperatorType",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "PowerSource",
                table: "Forklifts");

            migrationBuilder.AddColumn<string>(
                name: "EngineProductionNumber",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: ""
                );

            migrationBuilder.AlterColumn<string>(
                name: "OperatorAddress",
                table: "OperatorInformation",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "OperatorInformation",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Forklifts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "OperationMode",
                table: "ForkliftModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatorType",
                table: "ForkliftModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PowerSource",
                table: "ForkliftModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "InverterPerformance",
                table: "ElectricEngines",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "EngineOutput",
                table: "ElectricEngines",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_ModelId",
                table: "Forklifts",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_ForkliftModels_ModelId",
                table: "Forklifts",
                column: "ModelId",
                principalTable: "ForkliftModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_ForkliftModels_ModelId",
                table: "Forklifts");

            migrationBuilder.DropIndex(
                name: "IX_Forklifts_ModelId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "OperationMode",
                table: "ForkliftModels");

            migrationBuilder.DropColumn(
                name: "OperatorType",
                table: "ForkliftModels");

            migrationBuilder.DropColumn(
                name: "PowerSource",
                table: "ForkliftModels");

            migrationBuilder.DropColumn(
                name: "EngineProductionNumber",
                table: "Forklift");

            migrationBuilder.AddColumn<string>(
                name: "PowerSource",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: ""
                );

            migrationBuilder.AlterColumn<string>(
                name: "OperatorAddress",
                table: "OperatorInformation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "OperatorInformation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForkliftType",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatorType",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PowerSource",
                table: "Forklifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "InverterPerformance",
                table: "ElectricEngines",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "EngineOutput",
                table: "ElectricEngines",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateTable(
                name: "TechnicalInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineProductionNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalInformation_ForkliftModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ForkliftModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalInformation_Forklifts_Id",
                        column: x => x.Id,
                        principalTable: "Forklifts",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInformation_ModelId",
                table: "TechnicalInformation",
                column: "ModelId");
        }
    }
}

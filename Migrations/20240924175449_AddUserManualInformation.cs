using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddUserManualInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForkliftLeaseInformation_OperatorInformation_Id",
                table: "ForkliftLeaseInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForkliftLeaseInformation",
                table: "ForkliftLeaseInformation");

            migrationBuilder.RenameTable(
                name: "ForkliftLeaseInformation",
                newName: "LeaseInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaseInformation",
                table: "LeaseInformation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserManualInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfTransfer = table.Column<DateOnly>(type: "date", nullable: false),
                    SupplierType = table.Column<string>(type: "text", nullable: false),
                    SupplierSigneeName = table.Column<string>(type: "text", nullable: false),
                    SupplierSigneePosition = table.Column<string>(type: "text", nullable: false),
                    RecipientType = table.Column<string>(type: "text", nullable: false),
                    RecipientSigneeName = table.Column<string>(type: "text", nullable: false),
                    RecipientSigneePosition = table.Column<string>(type: "text", nullable: false),
                    IsOnlineManual = table.Column<bool>(type: "boolean", nullable: false),
                    ManualWebsite = table.Column<string>(type: "text", nullable: true),
                    LeaseReturnDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LeaseeSigneeName = table.Column<string>(type: "text", nullable: true),
                    LeaseeSigneePosition = table.Column<string>(type: "text", nullable: true),
                    LeaserSigneeName = table.Column<string>(type: "text", nullable: true),
                    LeaserSigneePosition = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManualInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserManualInformation_Forklifts_Id",
                        column: x => x.Id,
                        principalTable: "Forklifts",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseInformation_OperatorInformation_Id",
                table: "LeaseInformation",
                column: "Id",
                principalTable: "OperatorInformation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseInformation_OperatorInformation_Id",
                table: "LeaseInformation");

            migrationBuilder.DropTable(
                name: "UserManualInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaseInformation",
                table: "LeaseInformation");

            migrationBuilder.RenameTable(
                name: "LeaseInformation",
                newName: "ForkliftLeaseInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForkliftLeaseInformation",
                table: "ForkliftLeaseInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForkliftLeaseInformation_OperatorInformation_Id",
                table: "ForkliftLeaseInformation",
                column: "Id",
                principalTable: "OperatorInformation",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionalLeaseInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaseInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeaserCompany = table.Column<string>(type: "text", nullable: false),
                    LeaserName = table.Column<string>(type: "text", nullable: false),
                    LeaserOrgUnit = table.Column<string>(type: "text", nullable: false),
                    LeaserPosition = table.Column<string>(type: "text", nullable: false),
                    LeaserContact = table.Column<string>(type: "text", nullable: false),
                    LeaseeCompany = table.Column<string>(type: "text", nullable: false),
                    LeaseeName = table.Column<string>(type: "text", nullable: false),
                    LeaseeOrgUnit = table.Column<string>(type: "text", nullable: false),
                    LeaseePosition = table.Column<string>(type: "text", nullable: false),
                    LeaseeContact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForkliftLeaseInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForkliftLeaseInformation_OperatorInformation_Id",
                        column: x => x.Id,
                        principalTable: "OperatorInformation",
                        principalColumn: "Id");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaseInformation");
        }
    }
}

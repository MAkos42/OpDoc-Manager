using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class renamedOperationLocationToOperationArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationLocation",
                table: "OperatorInformation",
                newName: "OperationArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationArea",
                table: "OperatorInformation",
                newName: "OperationLocation");
        }
    }
}

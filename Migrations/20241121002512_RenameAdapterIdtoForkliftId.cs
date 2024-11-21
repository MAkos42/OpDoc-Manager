using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    /// <inheritdoc />
    public partial class RenameAdapterIdtoForkliftId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adapters_AdapterInformation_AdapterId",
                table: "Adapters");

            migrationBuilder.RenameColumn(
                name: "AdapterId",
                table: "Adapters",
                newName: "ForkliftId");

            migrationBuilder.RenameIndex(
                name: "IX_Adapters_AdapterId",
                table: "Adapters",
                newName: "IX_Adapters_ForkliftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapters_AdapterInformation_ForkliftId",
                table: "Adapters",
                column: "ForkliftId",
                principalTable: "AdapterInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adapters_AdapterInformation_ForkliftId",
                table: "Adapters");

            migrationBuilder.RenameColumn(
                name: "ForkliftId",
                table: "Adapters",
                newName: "AdapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Adapters_ForkliftId",
                table: "Adapters",
                newName: "IX_Adapters_AdapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapters_AdapterInformation_AdapterId",
                table: "Adapters",
                column: "AdapterId",
                principalTable: "AdapterInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

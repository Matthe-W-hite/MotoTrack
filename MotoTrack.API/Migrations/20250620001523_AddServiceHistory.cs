using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoTrack.API.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistory_Cars_CarId",
                table: "ServiceHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceHistory",
                table: "ServiceHistory");

            migrationBuilder.RenameTable(
                name: "ServiceHistory",
                newName: "ServiceHistories");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceHistory_CarId",
                table: "ServiceHistories",
                newName: "IX_ServiceHistories_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceHistories",
                table: "ServiceHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Cars_CarId",
                table: "ServiceHistories",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Cars_CarId",
                table: "ServiceHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceHistories",
                table: "ServiceHistories");

            migrationBuilder.RenameTable(
                name: "ServiceHistories",
                newName: "ServiceHistory");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceHistories_CarId",
                table: "ServiceHistory",
                newName: "IX_ServiceHistory_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceHistory",
                table: "ServiceHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistory_Cars_CarId",
                table: "ServiceHistory",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

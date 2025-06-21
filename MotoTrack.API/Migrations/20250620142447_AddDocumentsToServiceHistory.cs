using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoTrack.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentsToServiceHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Cars_CarId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ServiceHistoryId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ServiceHistoryId",
                table: "Documents",
                column: "ServiceHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Cars_CarId",
                table: "Documents",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ServiceHistories_ServiceHistoryId",
                table: "Documents",
                column: "ServiceHistoryId",
                principalTable: "ServiceHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Cars_CarId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ServiceHistories_ServiceHistoryId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ServiceHistoryId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ServiceHistoryId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Cars_CarId",
                table: "Documents",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

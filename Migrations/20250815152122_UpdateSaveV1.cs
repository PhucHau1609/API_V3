using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaveV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaveDatas_UserId",
                table: "SaveDatas");

            migrationBuilder.AddColumn<int>(
                name: "LastCheckpointID",
                table: "SaveDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastCheckpointScene",
                table: "SaveDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxHealth",
                table: "SaveDatas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SaveDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_SaveDatas_UserId",
                table: "SaveDatas",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaveDatas_UserId",
                table: "SaveDatas");

            migrationBuilder.DropColumn(
                name: "LastCheckpointID",
                table: "SaveDatas");

            migrationBuilder.DropColumn(
                name: "LastCheckpointScene",
                table: "SaveDatas");

            migrationBuilder.DropColumn(
                name: "MaxHealth",
                table: "SaveDatas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SaveDatas");

            migrationBuilder.CreateIndex(
                name: "IX_SaveDatas_UserId",
                table: "SaveDatas",
                column: "UserId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITManagement.Migrations
{
    /// <inheritdoc />
    public partial class addImgProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 21, 1, 23, 57, 462, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 21, 1, 23, 57, 462, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 21, 1, 23, 57, 462, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 21, 0, 20, 10, 672, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 21, 0, 20, 10, 672, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 21, 0, 20, 10, 672, DateTimeKind.Local).AddTicks(1472));
        }
    }
}

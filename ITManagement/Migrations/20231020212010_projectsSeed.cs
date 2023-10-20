using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITManagement.Migrations
{
    /// <inheritdoc />
    public partial class projectsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EmployeeId", "FinishProject", "Name" },
                values: new object[,]
                {
                    { 1, " Best IT desk", 1, new DateTime(2002, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desk IT Management" },
                    { 2, " Bank transaction online", 2, new DateTime(2007, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank Web Host" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 19, 22, 30, 13, 700, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 19, 22, 30, 13, 700, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfHire",
                value: new DateTime(2023, 10, 19, 22, 30, 13, 700, DateTimeKind.Local).AddTicks(1738));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedSuspensionInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41b3432b-bfd4-4537-a639-247a1fc68fc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c158b35a-2eaf-4c58-928e-c5bdb7dd6876");

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspensionEndDate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspensionStartDate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e219556b-bcca-41ef-ba58-858c9ca8f98f", "48bcb6ae-fbc8-4320-ac21-c43c85b97667", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bcbaea8-41ca-40d7-9f66-3a408a50b19e", "eef87c24-2c81-4084-b7a5-3cbf0557c745", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bcbaea8-41ca-40d7-9f66-3a408a50b19e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e219556b-bcca-41ef-ba58-858c9ca8f98f");

            migrationBuilder.DropColumn(
                name: "SuspensionEndDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SuspensionStartDate",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c158b35a-2eaf-4c58-928e-c5bdb7dd6876", "01d3eff7-9d87-4c94-8492-48b31d7d5a4d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41b3432b-bfd4-4537-a639-247a1fc68fc2", "3ae937d1-4eb8-4a91-b99f-5813093965e0", "Employee", "EMPLOYEE" });
        }
    }
}

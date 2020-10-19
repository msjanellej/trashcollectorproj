using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddtoCustDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "482b89ff-fb25-4529-b88b-ea1bf9aa1370");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83af12dd-4b65-4d28-a108-f42978740761");

            migrationBuilder.AddColumn<double>(
                name: "BalanceDue",
                table: "Customer",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickUp",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PickUpDay",
                table: "Customer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "798f9e0b-002f-42a0-a9d0-6f66a5e44ee6", "1cb2ae6d-bc0c-43ad-a2d1-c37c58a41152", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e758a941-27fd-4a36-812f-dc6531b12ac5", "b1da268d-8e88-467c-b05b-7fd8be50fa47", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798f9e0b-002f-42a0-a9d0-6f66a5e44ee6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e758a941-27fd-4a36-812f-dc6531b12ac5");

            migrationBuilder.DropColumn(
                name: "BalanceDue",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "OneTimePickUp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PickUpDay",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "482b89ff-fb25-4529-b88b-ea1bf9aa1370", "7b2f0c0f-c046-4ed7-9574-5393a3a4795a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83af12dd-4b65-4d28-a108-f42978740761", "62eaf254-658a-4307-a42d-a938797cfa53", "Employee", "EMPLOYEE" });
        }
    }
}

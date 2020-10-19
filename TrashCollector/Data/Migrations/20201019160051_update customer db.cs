using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class updatecustomerdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "286fd54e-604d-4ab7-836b-b5b2f27a7fa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4bf774a-baca-4a0f-97c3-2d93b4f640cd");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customer",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "482b89ff-fb25-4529-b88b-ea1bf9aa1370", "7b2f0c0f-c046-4ed7-9574-5393a3a4795a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83af12dd-4b65-4d28-a108-f42978740761", "62eaf254-658a-4307-a42d-a938797cfa53", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "482b89ff-fb25-4529-b88b-ea1bf9aa1370");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83af12dd-4b65-4d28-a108-f42978740761");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4bf774a-baca-4a0f-97c3-2d93b4f640cd", "5a92e116-4d9f-4606-895b-18d84835c46e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "286fd54e-604d-4ab7-836b-b5b2f27a7fa8", "62de3f59-a360-4bbb-82ed-36c68ab20ef0", "Employee", "EMPLOYEE" });
        }
    }
}

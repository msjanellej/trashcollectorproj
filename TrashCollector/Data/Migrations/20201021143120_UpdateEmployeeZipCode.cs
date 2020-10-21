using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class UpdateEmployeeZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a294247c-8fae-41f5-b3df-1275575469b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad164b0-e444-4f9a-b5f3-7dded33714fb");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5358714-f2a2-4baa-a195-3c4839dc8ff7", "7145ac30-7591-44be-9843-6127ee358708", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce8de236-5f73-4014-816a-3159d96d445f", "c26418a8-13cf-4cd5-96c8-b90ce7b65e59", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce8de236-5f73-4014-816a-3159d96d445f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5358714-f2a2-4baa-a195-3c4839dc8ff7");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a294247c-8fae-41f5-b3df-1275575469b7", "de806769-8dcb-4bf5-9cd9-d9cc256040b9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fad164b0-e444-4f9a-b5f3-7dded33714fb", "11af05f5-9285-4d49-b928-f593b1597edf", "Employee", "EMPLOYEE" });
        }
    }
}

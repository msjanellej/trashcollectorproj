using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class updateLatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2412469-8bbe-41c8-b075-60efc4cbd42b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f56982d4-ffa2-4961-8fcf-8a815157f946");

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efdf2316-7195-4582-914c-e539ee510309", "763d8714-ce7d-4a39-aa3a-95d955c6d6b7", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7bf6651-f159-494f-a254-bc0984363529", "c8b78344-c3d6-4530-b204-84092980bce3", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7bf6651-f159-494f-a254-bc0984363529");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efdf2316-7195-4582-914c-e539ee510309");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f56982d4-ffa2-4961-8fcf-8a815157f946", "dd3cd1c7-6f0a-475a-b198-167a0e9d2b24", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2412469-8bbe-41c8-b075-60efc4cbd42b", "38dc4a31-b1d9-416a-9342-5fca2d67a917", "Employee", "EMPLOYEE" });
        }
    }
}

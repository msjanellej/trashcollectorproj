using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Addtoemployeedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0734fb64-467d-4544-82d6-e428a2de80b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20036d2e-cf5e-4efd-a369-d7882426b59a");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Employee",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c158b35a-2eaf-4c58-928e-c5bdb7dd6876", "01d3eff7-9d87-4c94-8492-48b31d7d5a4d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41b3432b-bfd4-4537-a639-247a1fc68fc2", "3ae937d1-4eb8-4a91-b99f-5813093965e0", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41b3432b-bfd4-4537-a639-247a1fc68fc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c158b35a-2eaf-4c58-928e-c5bdb7dd6876");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20036d2e-cf5e-4efd-a369-d7882426b59a", "5582afd8-5a16-420e-a9b5-5996c8df3dc7", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0734fb64-467d-4544-82d6-e428a2de80b1", "f1ed3490-1162-4ac6-bf4d-802f5b9d823a", "Employee", "EMPLOYEE" });
        }
    }
}

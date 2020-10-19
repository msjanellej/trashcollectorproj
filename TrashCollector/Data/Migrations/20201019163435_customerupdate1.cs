using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class customerupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798f9e0b-002f-42a0-a9d0-6f66a5e44ee6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e758a941-27fd-4a36-812f-dc6531b12ac5");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20036d2e-cf5e-4efd-a369-d7882426b59a", "5582afd8-5a16-420e-a9b5-5996c8df3dc7", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0734fb64-467d-4544-82d6-e428a2de80b1", "f1ed3490-1162-4ac6-bf4d-802f5b9d823a", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0734fb64-467d-4544-82d6-e428a2de80b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20036d2e-cf5e-4efd-a369-d7882426b59a");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "798f9e0b-002f-42a0-a9d0-6f66a5e44ee6", "1cb2ae6d-bc0c-43ad-a2d1-c37c58a41152", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e758a941-27fd-4a36-812f-dc6531b12ac5", "b1da268d-8e88-467c-b05b-7fd8be50fa47", "Employee", "EMPLOYEE" });
        }
    }
}

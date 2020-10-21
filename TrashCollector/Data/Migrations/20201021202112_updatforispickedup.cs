using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class updatforispickedup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce8de236-5f73-4014-816a-3159d96d445f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5358714-f2a2-4baa-a195-3c4839dc8ff7");

            migrationBuilder.AddColumn<bool>(
                name: "isPickedUp",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2132bb2b-772f-4668-a9ae-68e29f461ecd", "2996d8fb-accc-466c-afdc-30830c65cb20", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac442ee0-04ad-4d0c-af1b-6222bcbb392f", "ef0fbb06-78ec-46ef-9e44-707ef2908158", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2132bb2b-772f-4668-a9ae-68e29f461ecd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac442ee0-04ad-4d0c-af1b-6222bcbb392f");

            migrationBuilder.DropColumn(
                name: "isPickedUp",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5358714-f2a2-4baa-a195-3c4839dc8ff7", "7145ac30-7591-44be-9843-6127ee358708", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce8de236-5f73-4014-816a-3159d96d445f", "c26418a8-13cf-4cd5-96c8-b90ce7b65e59", "Employee", "EMPLOYEE" });
        }
    }
}

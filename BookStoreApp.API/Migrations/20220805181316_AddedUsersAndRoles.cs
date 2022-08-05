using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class AddedUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b79bfd2-d7c5-443a-9783-a726b8cc7bb3", "f9ae2559-8083-456a-bf83-9edba19b4189", "User", "USER" },
                    { "a92d6035-764d-4ee1-a10a-4bafb5a56bd7", "f55007cc-26db-4915-a04a-01ff869f1842", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ed5c805-2e71-4d7d-a117-ea00604a884d", 0, "101ef5de-0283-4cd7-baa0-660dbd3f0203", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEFedg7KD6/HBTFqnXRNrPqAIyJOJ2VzNvBrPdlCcQGXzv88PRAl5PRdNs4R4Bpbmog==", null, false, "92259d22-6c80-44e3-b496-930abe08c0ec", false, "admin@bookstore.com" },
                    { "d1c84008-c154-4bc4-ab16-90c8a70a41de", 0, "86939049-c101-4c2a-abb3-d586e0305243", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEFl3Bs/Sh6Hvz9gYE810Itu4SNmQSRiaGLmCv7429VohAERqxcZOzg2sNcCnWj7Zhw==", null, false, "e2bd664b-cf36-416f-a0ff-f564f44202f2", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a92d6035-764d-4ee1-a10a-4bafb5a56bd7", "1ed5c805-2e71-4d7d-a117-ea00604a884d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2b79bfd2-d7c5-443a-9783-a726b8cc7bb3", "d1c84008-c154-4bc4-ab16-90c8a70a41de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a92d6035-764d-4ee1-a10a-4bafb5a56bd7", "1ed5c805-2e71-4d7d-a117-ea00604a884d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b79bfd2-d7c5-443a-9783-a726b8cc7bb3", "d1c84008-c154-4bc4-ab16-90c8a70a41de" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b79bfd2-d7c5-443a-9783-a726b8cc7bb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92d6035-764d-4ee1-a10a-4bafb5a56bd7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ed5c805-2e71-4d7d-a117-ea00604a884d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1c84008-c154-4bc4-ab16-90c8a70a41de");
        }
    }
}

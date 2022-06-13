using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_uppgift.Migrations
{
    public partial class addFlagAsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5763594a-a58b-4e24-9af0-82c75de7683a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f173608f-f1d0-4f5c-8634-1494d6858170", "f28e0df5-33f5-4fc2-9928-08273241c8b4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f173608f-f1d0-4f5c-8634-1494d6858170");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f28e0df5-33f5-4fc2-9928-08273241c8b4");

            migrationBuilder.AddColumn<bool>(
                name: "FlagAsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f215c86-f595-4eb9-b5b3-f834779bc17c", "9b08e861-6f28-4c22-bea6-e8b0865c51e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3abdd239-6420-4057-9559-3d5d4198ed82", "e33813c7-2de5-457b-b00e-9a7916c97cf5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FlagAsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8590df00-79e8-4492-b7af-2ebd2cda26b8", 0, "02/02/02", "7d54507d-aab8-431f-a874-98df75079dae", "admin@admin.com", false, "Adminsson", false, "Headersson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEHdt7Au7HT04gnoAQpInCG3hNfzyNiG7ulItRJiXsMflJjWgwShIrINI420pEwSycQ==", null, false, "75273ad5-87c4-4c17-933f-cce6191cc67a", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0f215c86-f595-4eb9-b5b3-f834779bc17c", "8590df00-79e8-4492-b7af-2ebd2cda26b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abdd239-6420-4057-9559-3d5d4198ed82");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f215c86-f595-4eb9-b5b3-f834779bc17c", "8590df00-79e8-4492-b7af-2ebd2cda26b8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f215c86-f595-4eb9-b5b3-f834779bc17c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8590df00-79e8-4492-b7af-2ebd2cda26b8");

            migrationBuilder.DropColumn(
                name: "FlagAsAdmin",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5763594a-a58b-4e24-9af0-82c75de7683a", "99ad9889-66a5-4fab-a9c9-d67d26fefb2d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f173608f-f1d0-4f5c-8634-1494d6858170", "ba294d53-1f06-45da-9b62-193e1b7c48d5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f28e0df5-33f5-4fc2-9928-08273241c8b4", 0, "02/02/02", "991c7da6-1b27-4cbc-9aa7-6998c3dcb6ae", "admin@admin.com", false, "Adminsson", "Headersson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJ/Du4ldpPy7R9LeUwqhbSqCCY3GWeTUaGMvSiRkr1B6GGaiFh9noJKPvvfiF+NyUg==", null, false, "1f91bc36-3e09-46fb-8ac5-f96858ffb5d5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f173608f-f1d0-4f5c-8634-1494d6858170", "f28e0df5-33f5-4fc2-9928-08273241c8b4" });
        }
    }
}

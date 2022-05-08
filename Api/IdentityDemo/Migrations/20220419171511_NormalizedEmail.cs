using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityDemo.Migrations
{
    public partial class NormalizedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9269bda7-25ae-4679-8ba5-49f28a58284a",
                column: "ConcurrencyStamp",
                value: "20936729-7769-41a6-82d1-9d6b7261753a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b894f3e4-0781-4302-9264-a30d6e925973",
                column: "ConcurrencyStamp",
                value: "5c3ec49b-f9ff-4e1b-9955-0d7b50a01886");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f355d1b-111e-4056-bbce-08135c33c255", "MAJID@TEST.COM", "MAJID", "AQAAAAEAACcQAAAAEBNyYwnpbvOnRHNY3CtaChfOayG7nDLqxjyAhjzJHcZQnNLm1TfYmSVRjWkoXsqo5g==", "61d06079-b92b-4384-8090-3226f49f7cff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4049ff33-6e91-46d4-b747-4be3e6681731",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b129e9f-79d1-4ba3-8268-deb973ef6cae", "ADMIN@TEST.COM", "ADMIN", "AQAAAAEAACcQAAAAEJ7m4sb8p0OxysDkh1aFdhCee+pOp07ZANIchd0d4qsX6OyssPJylRZdNIxnPZqbag==", "f5169edb-2200-4fe0-961c-54e4833250fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebe9598f-616d-4e7f-9b38-0f841cc39883",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7847515c-745e-4b21-b66d-7f9058a4595c", "BOB@TEST.COM", "BOB", "AQAAAAEAACcQAAAAEIIWSUTQFNPAtbromJwQPHw0VsYA93MiZKbQrm5KjAZBT+jURWaAs34ZapuptBxbXw==", "00ea98a1-4064-4edd-a66d-4744d96fac0d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9269bda7-25ae-4679-8ba5-49f28a58284a",
                column: "ConcurrencyStamp",
                value: "89f6a71d-899f-4f55-9169-8ff9b767caf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b894f3e4-0781-4302-9264-a30d6e925973",
                column: "ConcurrencyStamp",
                value: "7436d409-3b49-4e61-aa2d-aecac9fe7083");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "717c4945-ce2f-4915-a4d1-f63b97e7738c", null, null, "AQAAAAEAACcQAAAAEB4cDlK1/Rs7wcfK3/AbRvQTcGb912g4qbLroRb/3D/glkH1jtrInQNy6QPtMUmmkw==", "3eaa296f-7657-45b4-b80b-6cfca6927474" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4049ff33-6e91-46d4-b747-4be3e6681731",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a5402f-f3bd-40d5-b9f0-093225e2a073", null, null, "AQAAAAEAACcQAAAAEGcu3mbGNrV2oWuQKQLSmtfFh6uBqjSE/89TIL7COufruQ898yRXh479XLenoO7rPA==", "b3226bf0-e807-4aeb-9cf3-acb9e7d452df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebe9598f-616d-4e7f-9b38-0f841cc39883",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbaf47da-930d-4f85-bc47-ff7beb7500dd", null, null, "AQAAAAEAACcQAAAAEG3lad/hBn6umovdoN433ODxl9j2revmGycU0BkSGcEvbZW1/mYDrjk3AsBHhAbjwA==", "1e29f8cf-dab0-4ede-950c-0773819f64a5" });
        }
    }
}

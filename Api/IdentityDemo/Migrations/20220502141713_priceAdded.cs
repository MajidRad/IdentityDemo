using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityDemo.Migrations
{
    public partial class priceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9269bda7-25ae-4679-8ba5-49f28a58284a",
                column: "ConcurrencyStamp",
                value: "1f6cbc16-8f9a-410e-ae96-62ba6c2d52c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b894f3e4-0781-4302-9264-a30d6e925973",
                column: "ConcurrencyStamp",
                value: "7d884c09-df40-4975-a2bd-08879635e75b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a914703-5819-43db-830f-920420ea2f3e", "AQAAAAEAACcQAAAAEL8bxSJjhhdKkdn26Ga3qBIHtL9EtUPWC6TwSUERL3I/ifcn4Dgkuj/ICel7oXGFsA==", "4a56f6ef-4faa-49e3-9d32-d0cf1c8295e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4049ff33-6e91-46d4-b747-4be3e6681731",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15a724b0-0254-4d82-9c84-fad02aa90cc9", "AQAAAAEAACcQAAAAEGZYgCaPm5YubTwBVeV5uCMfyVoTg6izN3wY9WGVE9sw1u0zS8YNAMN0Ejts6Qx20Q==", "5183638a-c719-4693-a2dd-5789e317ff52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebe9598f-616d-4e7f-9b38-0f841cc39883",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "452d0854-0029-446d-9c8d-d3209b6be61d", "AQAAAAEAACcQAAAAEPPJc+fViW42v50QlTmxE3ZGTQ83sd0oQgPk7V4BCIETFBMdxVEfaVoWfkkamVaoFg==", "1ecce4d2-ddb9-421a-9560-2e2b3d76bbb9" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 500000m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 240000m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 54000m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 66000m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 75000m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 44000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f355d1b-111e-4056-bbce-08135c33c255", "AQAAAAEAACcQAAAAEBNyYwnpbvOnRHNY3CtaChfOayG7nDLqxjyAhjzJHcZQnNLm1TfYmSVRjWkoXsqo5g==", "61d06079-b92b-4384-8090-3226f49f7cff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4049ff33-6e91-46d4-b747-4be3e6681731",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b129e9f-79d1-4ba3-8268-deb973ef6cae", "AQAAAAEAACcQAAAAEJ7m4sb8p0OxysDkh1aFdhCee+pOp07ZANIchd0d4qsX6OyssPJylRZdNIxnPZqbag==", "f5169edb-2200-4fe0-961c-54e4833250fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebe9598f-616d-4e7f-9b38-0f841cc39883",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7847515c-745e-4b21-b66d-7f9058a4595c", "AQAAAAEAACcQAAAAEIIWSUTQFNPAtbromJwQPHw0VsYA93MiZKbQrm5KjAZBT+jURWaAs34ZapuptBxbXw==", "00ea98a1-4064-4edd-a66d-4744d96fac0d" });
        }
    }
}

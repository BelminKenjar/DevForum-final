using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class updateSubtopicModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostCount",
                table: "SubTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "6b625733-fb1d-46ea-85bb-4f742a175fda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba9c1985-46db-4cad-a6a7-075ef0683b22", "AQAAAAEAACcQAAAAEHayofGZ1T0GaOj7HZzit5Ie6I/eUXBYJFT9ZpS/63eZEhgQPkcLsizfKbrRvxcfug==", "ea39f6f9-f29b-4607-b3b0-d7865358844d" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 742, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 742, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 739, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 742, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 22, 18, 8, 743, DateTimeKind.Local).AddTicks(1424));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostCount",
                table: "SubTopics");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "e5ab0729-814e-4d12-a280-9edd81dfc0a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58e3b0b9-b4f6-406a-9248-795079798c40", "AQAAAAEAACcQAAAAEAtQYf5iotHRByQvA7tvgPeobGt1FejRMzek1aSr/1GdYkugrlBkEcqKvIzivi/WxQ==", "2d0bfb81-31af-4be9-a79c-f0cfd7ce36a7" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 218, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 219, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 214, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 268, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 268, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 268, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 268, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 268, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 268, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 219, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 241, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 17, 13, 24, 35, 249, DateTimeKind.Local).AddTicks(7912));
        }
    }
}

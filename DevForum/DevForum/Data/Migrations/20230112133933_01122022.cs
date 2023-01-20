using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class _01122022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "fbe4710d-1aa8-4dca-9492-da5ec0673b39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49b85c6a-1f8f-4180-b57e-7c81964c159f", "AQAAAAEAACcQAAAAEJHgqCo2NIdHljvMplRMXvqWmb/mcKbec4cw0PsMxUdKKq6l3b53a6GPHynAi3zm5g==", "226c2cee-f570-4646-8ab5-d4fbba72624c" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 817, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 817, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 811, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 819, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 819, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 819, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 819, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 819, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 819, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 817, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 818, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 12, 14, 39, 32, 818, DateTimeKind.Local).AddTicks(1819));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "d7e0d781-e10d-498d-9593-e8e047ae8a08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ef35e17-4ed9-4d64-9b27-6531e2334771", "AQAAAAEAACcQAAAAEK/0VcuW/cjnNo/NjrFZqgEGv+fZ0kDin06J78lqvjBDcmOLTM8pGknY4QwZXJ367g==", "ae417d08-2756-4ed5-8e17-18afd8d1437b" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 335, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 335, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 327, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 340, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 335, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 337, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 22, 20, 20, 35, 338, DateTimeKind.Local).AddTicks(6415));
        }
    }
}

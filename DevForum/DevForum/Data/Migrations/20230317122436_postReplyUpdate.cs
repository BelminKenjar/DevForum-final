using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class postReplyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "PostReplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "PostReplies");

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
    }
}

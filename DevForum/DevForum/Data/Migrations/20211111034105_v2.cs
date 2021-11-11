using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "c1e264a7-f9fb-42c1-b274-b4b2cf196b1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "542cc9e6-cb5a-40b6-b233-f5b17c37ea0d", "AQAAAAEAACcQAAAAEOTqjtEKlmTVzcTegKgwFuTQUM3PemFt4TlqTTR3gBv1TjR9RkIov0tdewtB6zc4NA==", "35dc7853-2eb9-46a0-a1cb-d1c5215da1cb" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 11, 4, 41, 4, 494, DateTimeKind.Local).AddTicks(5693));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "cfdb69ae-5d70-42bf-ab8c-56aef1e9e3ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cca276ff-527c-477a-a6e6-7325c1915e2a", "AQAAAAEAACcQAAAAEAktwrK8SmJNRx0MIzsYEy4tDrOvNM/Nosmk2bLABa1rw2tZfSw258+jFUousAap9A==", "b178b80a-f3e3-4b1a-a8bf-eafd46ceb73f" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 10, 23, 26, 24, 118, DateTimeKind.Local).AddTicks(6815));
        }
    }
}

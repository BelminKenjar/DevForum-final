using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class seedstatsanddetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "88503b96-8014-4e06-ace0-e5f767a8a46d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "160e5951-00ef-4a39-ac1c-5f440c08b9af", "AQAAAAEAACcQAAAAEIyvm+DDB+EQ/1g/sxyhwm88IfDDj4Js+p1MW+SRs8gZ0FWqDXdlKAgPWp3nreMemA==", "cf03ab6f-421a-48a4-a149-43f490e85cdd" });

            migrationBuilder.InsertData(
                table: "ProfileDetails",
                columns: new[] { "Id", "Age", "City", "Country", "FacebookUrl", "GithubUrl", "LinkedinUrl", "ProfileId", "TwitterUrl", "Website" },
                values: new object[] { 1, 32, "Sanski Most", "BiH", "https://facebook.com", "https://github.com", "https://linkedin.com", 1, "https://twitter.com", "https://googla.ba" });

            migrationBuilder.InsertData(
                table: "ProfileStats",
                columns: new[] { "Id", "PostsCommented", "PostsCreated", "ProfileId", "Rating" },
                values: new object[] { 1, 3, 2, 1, 13 });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 15, 20, 55, 18, 428, DateTimeKind.Local).AddTicks(3871));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProfileDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProfileStats",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}

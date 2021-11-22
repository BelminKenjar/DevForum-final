using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class seedSubtopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "SubTopics",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProfileId", "TopicId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 22, 20, 20, 35, 340, DateTimeKind.Local).AddTicks(9297), "C++ is one of the preferred languages for game development as it supports a variety of coding styles that provides low-level access to the system", "C++", 1, 1 },
                    { 2, new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1667), "Game development & design made fun", "C# Unity", 1, 1 },
                    { 3, new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1690), "Node.js® is a JavaScript runtime built on Chrome's V8 JavaScript engine.", "NodeJS", 1, 2 },
                    { 4, new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1695), "Java — Backend Language #1", "Java", 1, 2 },
                    { 5, new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1699), "The C# language is the preferred architecture for backend programming and automation in Windows environments.", "C#", 1, 2 },
                    { 6, new DateTime(2021, 11, 22, 20, 20, 35, 341, DateTimeKind.Local).AddTicks(1704), "HTML (the Hypertext Markup Language) and CSS (Cascading Style Sheets) are two of the core technologies for building Web pages.", "HTML&CSS", 1, 3 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubTopics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "b6c4216a-d425-402d-958f-5a16947890ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06e8d286-13db-4686-ac17-2357cee23abf", "AQAAAAEAACcQAAAAEIHhidIiuPNR5OpSM3lQ+pwvrtvWgSiZtRfM0ntsiRvDAXj2wUyPgnCwrda5rrWJ4w==", "8577c37e-f55f-4e1b-8810-e1a140d18eac" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 21, 3, 43, 57, 425, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 21, 3, 43, 57, 425, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 21, 3, 43, 57, 419, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 21, 3, 43, 57, 425, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 21, 3, 43, 57, 426, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 21, 3, 43, 57, 434, DateTimeKind.Local).AddTicks(2838));
        }
    }
}

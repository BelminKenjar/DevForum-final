using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevForum.Data.Migrations
{
    public partial class seedNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d89570c-41f5-4230-9bac-1f97b925e2f0",
                column: "ConcurrencyStamp",
                value: "00df25ac-f575-49dc-a27b-008cf3cb598d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c48c0e84-c0e5-48a4-8e36-0b584bc83a2d", "AQAAAAEAACcQAAAAENuXcb/qeMPYAGDj1bznq0srCtVNDW8OKAK6PzNsFoggeyaZw1/6n8XnrQrIFT0ZbA==", "f03b4759-6cf8-4eea-9bf3-34ae40beba27" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedAt", "EditedAt", "ProfileId", "Title" },
                values: new object[,]
                {
                    { 1, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?", new DateTime(2021, 11, 19, 2, 23, 19, 371, DateTimeKind.Local).AddTicks(4781), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Welcome to DevForum!" },
                    { 2, "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.", new DateTime(2021, 11, 19, 2, 23, 19, 371, DateTimeKind.Local).AddTicks(5863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Register new account" }
                });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 19, 2, 23, 19, 365, DateTimeKind.Local).AddTicks(7512));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 15, 20, 55, 18, 428, DateTimeKind.Local).AddTicks(3871));
        }
    }
}

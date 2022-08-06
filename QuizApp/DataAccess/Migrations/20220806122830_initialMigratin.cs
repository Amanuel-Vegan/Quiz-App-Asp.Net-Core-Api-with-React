using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initialMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TimeTaken = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QnInWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_participants_Email",
                table: "participants",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Option1",
                table: "questions",
                column: "Option1",
                unique: true,
                filter: "[Option1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Option2",
                table: "questions",
                column: "Option2",
                unique: true,
                filter: "[Option2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Option3",
                table: "questions",
                column: "Option3",
                unique: true,
                filter: "[Option3] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Option4",
                table: "questions",
                column: "Option4",
                unique: true,
                filter: "[Option4] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}

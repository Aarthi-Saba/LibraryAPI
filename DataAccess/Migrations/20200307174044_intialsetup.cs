using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class intialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users Info",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users Info", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books Collection",
                columns: table => new
                {
                    ISBN = table.Column<Guid>(nullable: false),
                    BookName = table.Column<string>(name: "Book Name", nullable: true),
                    PublishedDate = table.Column<DateTime>(name: "Published Date", nullable: false),
                    CheckedOut = table.Column<bool>(name: "Checked Out", nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BookUserInfoUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books Collection", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books Collection_Users Info_BookUserInfoUserId",
                        column: x => x.BookUserInfoUserId,
                        principalTable: "Users Info",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books Collection_BookUserInfoUserId",
                table: "Books Collection",
                column: "BookUserInfoUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books Collection");

            migrationBuilder.DropTable(
                name: "Users Info");
        }
    }
}

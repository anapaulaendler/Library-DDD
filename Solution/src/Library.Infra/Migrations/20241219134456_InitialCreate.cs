using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Isbn = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    PublicationYear = table.Column<string>(type: "TEXT", nullable: false),
                    IsBorrowed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Fine = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "IsBorrowed", "Isbn", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { new Guid("22583aa3-b586-4d2f-9144-dd701126a487"), "Aldous Huxley", "Science Fiction", false, "9780060850524", "1932", "Brave New World" },
                    { new Guid("5290e6b1-e26a-4d7f-880a-94278c46b4dc"), "J.D. Salinger", "Fiction", false, "9780316769488", "1951", "The Catcher in the Rye" },
                    { new Guid("9a866ef3-cdbe-4d71-9d46-510d2a505562"), "F. Scott Fitzgerald", "Classic", false, "9780743273565", "1925", "The Great Gatsby" },
                    { new Guid("c6e4a1a8-afb6-4136-875c-491f1e421b2d"), "George Orwell", "Dystopian", false, "9780451524935", "1949", "1984" },
                    { new Guid("cb8ded69-62a0-4a09-8186-16258574d1e0"), "Harper Lee", "Fiction", false, "9780061120084", "1960", "To Kill a Mockingbird" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("058fff06-30b5-4f6f-8dcd-3a5dd9e38440"), "bob@example.com", "Bob", (byte)1 },
                    { new Guid("4de942c8-c2f1-409f-bd1c-bf126e6847fd"), "eve@example.com", "Eve", (byte)2 },
                    { new Guid("9c5359aa-2548-402f-90a0-c7e82fe225ae"), "charlie@example.com", "Charlie", (byte)0 },
                    { new Guid("9f0fc384-9407-4053-b023-8f4f567dafad"), "alice@example.com", "Alice", (byte)2 },
                    { new Guid("f047a248-dd4d-4ab4-b021-11160d6a5396"), "diana@example.com", "Diana", (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

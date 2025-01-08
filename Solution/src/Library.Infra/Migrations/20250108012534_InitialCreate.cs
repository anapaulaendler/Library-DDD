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
                    Password = table.Column<string>(type: "TEXT", nullable: false),
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
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false),
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
                    { new Guid("0fd8f8a0-831c-46d3-86d0-57b9e5d3c2fb"), "Aldous Huxley", "Science Fiction", false, "9780060850524", "1932", "Brave New World" },
                    { new Guid("3d2c69ea-31f0-4388-9c43-5c60f97cfd12"), "George Orwell", "Dystopian", false, "9780451524935", "1949", "1984" },
                    { new Guid("7ac248f3-e8db-4d69-938e-faaa362a7134"), "F. Scott Fitzgerald", "Classic", false, "9780743273565", "1925", "The Great Gatsby" },
                    { new Guid("90c4eeaa-345c-4c1d-96e3-16a65fb7cb54"), "Harper Lee", "Fiction", false, "9780061120084", "1960", "To Kill a Mockingbird" },
                    { new Guid("e2f4a0b1-68da-4462-9a40-31e3fd6f0f45"), "J.D. Salinger", "Fiction", false, "9780316769488", "1951", "The Catcher in the Rye" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("0f5c13a7-ba67-43ae-ae16-ac7407a86728"), "charlie@example.com", "Charlie", "123@abc", (byte)0 },
                    { new Guid("1b71e805-fc38-4bb2-9988-847327b7b445"), "alice@example.com", "Alice", "123@abc", (byte)2 },
                    { new Guid("4bc915b5-8a13-4d74-a848-388b6c976221"), "eve@example.com", "Eve", "123@abc", (byte)2 },
                    { new Guid("9ac2f2e0-2979-4ebe-9104-9fcb81db70fa"), "bob@example.com", "Bob", "123@abc", (byte)1 },
                    { new Guid("f1e06fd6-d5ac-4ed6-906a-447513114e77"), "diana@example.com", "Diana", "123@abc", (byte)2 }
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

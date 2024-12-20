using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Infra.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("22583aa3-b586-4d2f-9144-dd701126a487"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5290e6b1-e26a-4d7f-880a-94278c46b4dc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9a866ef3-cdbe-4d71-9d46-510d2a505562"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c6e4a1a8-afb6-4136-875c-491f1e421b2d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cb8ded69-62a0-4a09-8186-16258574d1e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("058fff06-30b5-4f6f-8dcd-3a5dd9e38440"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4de942c8-c2f1-409f-bd1c-bf126e6847fd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c5359aa-2548-402f-90a0-c7e82fe225ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f0fc384-9407-4053-b023-8f4f567dafad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f047a248-dd4d-4ab4-b021-11160d6a5396"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "IsBorrowed", "Isbn", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { new Guid("a516634d-6cbd-4b46-b7c0-a41246145c27"), "Aldous Huxley", "Science Fiction", false, "9780060850524", "1932", "Brave New World" },
                    { new Guid("a984ed46-297d-4165-8dd4-703c1cc7069a"), "George Orwell", "Dystopian", false, "9780451524935", "1949", "1984" },
                    { new Guid("ba796368-e128-459b-bd12-fea7b0c05f6f"), "Harper Lee", "Fiction", false, "9780061120084", "1960", "To Kill a Mockingbird" },
                    { new Guid("c9b7f2f2-2b71-400f-8db2-71254ee526b7"), "J.D. Salinger", "Fiction", false, "9780316769488", "1951", "The Catcher in the Rye" },
                    { new Guid("e3c162c3-4320-4ff1-980a-203e24e99a9b"), "F. Scott Fitzgerald", "Classic", false, "9780743273565", "1925", "The Great Gatsby" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("2d3aaf51-dc40-457d-b269-9a87187a4148"), "bob@example.com", "Bob", (byte)1 },
                    { new Guid("3b265ac2-c4d1-42be-926b-54f2f2208671"), "charlie@example.com", "Charlie", (byte)0 },
                    { new Guid("5e24816f-7085-4aad-9d9b-274ee91fae00"), "eve@example.com", "Eve", (byte)2 },
                    { new Guid("b3713df6-ece1-4649-a596-29398130cdee"), "diana@example.com", "Diana", (byte)2 },
                    { new Guid("baaa7c3f-4bdf-4f09-a8b9-d805269688b1"), "alice@example.com", "Alice", (byte)2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a516634d-6cbd-4b46-b7c0-a41246145c27"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a984ed46-297d-4165-8dd4-703c1cc7069a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ba796368-e128-459b-bd12-fea7b0c05f6f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c9b7f2f2-2b71-400f-8db2-71254ee526b7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e3c162c3-4320-4ff1-980a-203e24e99a9b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d3aaf51-dc40-457d-b269-9a87187a4148"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b265ac2-c4d1-42be-926b-54f2f2208671"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5e24816f-7085-4aad-9d9b-274ee91fae00"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b3713df6-ece1-4649-a596-29398130cdee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("baaa7c3f-4bdf-4f09-a8b9-d805269688b1"));

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
        }
    }
}

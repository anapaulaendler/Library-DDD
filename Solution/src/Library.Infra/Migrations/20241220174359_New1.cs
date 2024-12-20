using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Infra.Migrations
{
    /// <inheritdoc />
    public partial class New1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("08f255e5-96aa-4ae1-90cc-76a882431d2c"), "Harper Lee", "Fiction", false, "9780061120084", "1960", "To Kill a Mockingbird" },
                    { new Guid("1b9504b1-7940-4285-8acf-62acb09ad5eb"), "George Orwell", "Dystopian", false, "9780451524935", "1949", "1984" },
                    { new Guid("1ed9ef42-0b2e-4f55-90e5-4283448c902c"), "Aldous Huxley", "Science Fiction", false, "9780060850524", "1932", "Brave New World" },
                    { new Guid("4b338981-e239-4457-a071-3ef87b0655f4"), "J.D. Salinger", "Fiction", false, "9780316769488", "1951", "The Catcher in the Rye" },
                    { new Guid("d49c6375-035d-48aa-868c-295cc5c0139c"), "F. Scott Fitzgerald", "Classic", false, "9780743273565", "1925", "The Great Gatsby" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("767d5353-88ac-4f54-976e-864ce1cdeb15"), "alice@example.com", "Alice", (byte)2 },
                    { new Guid("7f58efc0-ed98-4bd9-a934-74c3e43f7f1a"), "charlie@example.com", "Charlie", (byte)0 },
                    { new Guid("84a35af5-3a39-44a4-a7fa-736ee7df08e1"), "diana@example.com", "Diana", (byte)2 },
                    { new Guid("a7e7e46f-90ba-441f-9b08-9de566fe01a5"), "eve@example.com", "Eve", (byte)2 },
                    { new Guid("c338c40f-de7c-4b7a-876d-4ebd75faff87"), "bob@example.com", "Bob", (byte)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("08f255e5-96aa-4ae1-90cc-76a882431d2c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1b9504b1-7940-4285-8acf-62acb09ad5eb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1ed9ef42-0b2e-4f55-90e5-4283448c902c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b338981-e239-4457-a071-3ef87b0655f4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d49c6375-035d-48aa-868c-295cc5c0139c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("767d5353-88ac-4f54-976e-864ce1cdeb15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7f58efc0-ed98-4bd9-a934-74c3e43f7f1a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84a35af5-3a39-44a4-a7fa-736ee7df08e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7e7e46f-90ba-441f-9b08-9de566fe01a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c338c40f-de7c-4b7a-876d-4ebd75faff87"));

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
    }
}

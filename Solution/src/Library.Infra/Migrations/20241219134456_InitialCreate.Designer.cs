﻿// <auto-generated />
using System;
using Library.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241219134456_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Library.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicationYear")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6e4a1a8-afb6-4136-875c-491f1e421b2d"),
                            Author = "George Orwell",
                            Genre = "Dystopian",
                            IsBorrowed = false,
                            Isbn = "9780451524935",
                            PublicationYear = "1949",
                            Title = "1984"
                        },
                        new
                        {
                            Id = new Guid("cb8ded69-62a0-4a09-8186-16258574d1e0"),
                            Author = "Harper Lee",
                            Genre = "Fiction",
                            IsBorrowed = false,
                            Isbn = "9780061120084",
                            PublicationYear = "1960",
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = new Guid("9a866ef3-cdbe-4d71-9d46-510d2a505562"),
                            Author = "F. Scott Fitzgerald",
                            Genre = "Classic",
                            IsBorrowed = false,
                            Isbn = "9780743273565",
                            PublicationYear = "1925",
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = new Guid("22583aa3-b586-4d2f-9144-dd701126a487"),
                            Author = "Aldous Huxley",
                            Genre = "Science Fiction",
                            IsBorrowed = false,
                            Isbn = "9780060850524",
                            PublicationYear = "1932",
                            Title = "Brave New World"
                        },
                        new
                        {
                            Id = new Guid("5290e6b1-e26a-4d7f-880a-94278c46b4dc"),
                            Author = "J.D. Salinger",
                            Genre = "Fiction",
                            IsBorrowed = false,
                            Isbn = "9780316769488",
                            PublicationYear = "1951",
                            Title = "The Catcher in the Rye"
                        });
                });

            modelBuilder.Entity("Library.Domain.Models.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fine")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f0fc384-9407-4053-b023-8f4f567dafad"),
                            Email = "alice@example.com",
                            Name = "Alice",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = new Guid("058fff06-30b5-4f6f-8dcd-3a5dd9e38440"),
                            Email = "bob@example.com",
                            Name = "Bob",
                            Role = (byte)1
                        },
                        new
                        {
                            Id = new Guid("9c5359aa-2548-402f-90a0-c7e82fe225ae"),
                            Email = "charlie@example.com",
                            Name = "Charlie",
                            Role = (byte)0
                        },
                        new
                        {
                            Id = new Guid("f047a248-dd4d-4ab4-b021-11160d6a5396"),
                            Email = "diana@example.com",
                            Name = "Diana",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = new Guid("4de942c8-c2f1-409f-bd1c-bf126e6847fd"),
                            Email = "eve@example.com",
                            Name = "Eve",
                            Role = (byte)2
                        });
                });

            modelBuilder.Entity("Library.Domain.Models.Loan", b =>
                {
                    b.HasOne("Library.Domain.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

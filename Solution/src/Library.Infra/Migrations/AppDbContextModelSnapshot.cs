﻿// <auto-generated />
using System;
using Library.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("1b9504b1-7940-4285-8acf-62acb09ad5eb"),
                            Author = "George Orwell",
                            Genre = "Dystopian",
                            IsBorrowed = false,
                            Isbn = "9780451524935",
                            PublicationYear = "1949",
                            Title = "1984"
                        },
                        new
                        {
                            Id = new Guid("08f255e5-96aa-4ae1-90cc-76a882431d2c"),
                            Author = "Harper Lee",
                            Genre = "Fiction",
                            IsBorrowed = false,
                            Isbn = "9780061120084",
                            PublicationYear = "1960",
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = new Guid("d49c6375-035d-48aa-868c-295cc5c0139c"),
                            Author = "F. Scott Fitzgerald",
                            Genre = "Classic",
                            IsBorrowed = false,
                            Isbn = "9780743273565",
                            PublicationYear = "1925",
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = new Guid("1ed9ef42-0b2e-4f55-90e5-4283448c902c"),
                            Author = "Aldous Huxley",
                            Genre = "Science Fiction",
                            IsBorrowed = false,
                            Isbn = "9780060850524",
                            PublicationYear = "1932",
                            Title = "Brave New World"
                        },
                        new
                        {
                            Id = new Guid("4b338981-e239-4457-a071-3ef87b0655f4"),
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
                            Id = new Guid("767d5353-88ac-4f54-976e-864ce1cdeb15"),
                            Email = "alice@example.com",
                            Name = "Alice",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = new Guid("c338c40f-de7c-4b7a-876d-4ebd75faff87"),
                            Email = "bob@example.com",
                            Name = "Bob",
                            Role = (byte)1
                        },
                        new
                        {
                            Id = new Guid("7f58efc0-ed98-4bd9-a934-74c3e43f7f1a"),
                            Email = "charlie@example.com",
                            Name = "Charlie",
                            Role = (byte)0
                        },
                        new
                        {
                            Id = new Guid("84a35af5-3a39-44a4-a7fa-736ee7df08e1"),
                            Email = "diana@example.com",
                            Name = "Diana",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = new Guid("a7e7e46f-90ba-441f-9b08-9de566fe01a5"),
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

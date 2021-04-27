﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ticketr.Models;

namespace Ticketr.Migrations
{
    [DbContext(typeof(TicketrContext))]
    partial class TicketrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ticketr.Models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("DonationAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("PatronId")
                        .HasColumnType("int");

                    b.HasKey("DonationId");

                    b.HasIndex("PatronId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Ticketr.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventCode")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PriceMap")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Ticketr.Models.Patron", b =>
                {
                    b.Property<int>("PatronId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsMilitary")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumberType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SubscriptionModule")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("TotalDonations")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PatronId");

                    b.HasIndex("UserId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("Ticketr.Models.PatronSeriesRel", b =>
                {
                    b.Property<int>("PatronSeriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PatronId")
                        .HasColumnType("int");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PatronSeriesId");

                    b.HasIndex("PatronId");

                    b.HasIndex("SeriesId");

                    b.ToTable("PatronSeriesRels");
                });

            modelBuilder.Entity("Ticketr.Models.PurchasedTicket", b =>
                {
                    b.Property<int>("PurchasedTicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PatronId")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketCost")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("PurchasedTicketId");

                    b.HasIndex("PatronId");

                    b.ToTable("PurchasedTickets");
                });

            modelBuilder.Entity("Ticketr.Models.Series", b =>
                {
                    b.Property<int>("SeriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CombinedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("NetSales")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("SeriesDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SeriesName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("SeriesTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SeriesVenue")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("TicketsAvailable")
                        .HasColumnType("int");

                    b.Property<int>("TicketsSold")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalDiscounts")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SeriesId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Ticketr.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccessLevel")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ticketr.Models.Donation", b =>
                {
                    b.HasOne("Ticketr.Models.Patron", "Patron")
                        .WithMany("DonationsMade")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketr.Models.Event", b =>
                {
                    b.HasOne("Ticketr.Models.User", "CreatedBy")
                        .WithMany("EventsMade")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketr.Models.Patron", b =>
                {
                    b.HasOne("Ticketr.Models.User", "User")
                        .WithMany("PatronsAdded")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketr.Models.PatronSeriesRel", b =>
                {
                    b.HasOne("Ticketr.Models.Patron", "Patron")
                        .WithMany("SeriesSeen")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ticketr.Models.Series", "Series")
                        .WithMany("PatronsWatched")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketr.Models.PurchasedTicket", b =>
                {
                    b.HasOne("Ticketr.Models.Patron", "Patron")
                        .WithMany()
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketr.Models.Series", b =>
                {
                    b.HasOne("Ticketr.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ticketr.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

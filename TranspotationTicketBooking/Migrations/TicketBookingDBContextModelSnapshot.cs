﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranspotationTicketBooking.Models;

namespace TranspotationTicketBooking.Migrations
{
    [DbContext(typeof(TicketBookingDBContext))]
    partial class TicketBookingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "b7ff0b9d-71b6-4abc-a94f-66d1cd51fc68",
                            ConcurrencyStamp = "9e17bc6e-78f4-42a0-aea8-7d3041c9eb75",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = "f24be4a5-a363-4b0d-83f8-5c60d3305796",
                            ConcurrencyStamp = "7bffab89-0107-4f37-9687-96b0609c0f50",
                            Name = "Passenger",
                            NormalizedName = "PASSENGER"
                        },
                        new
                        {
                            Id = "7c43532b-cd3d-4e36-afb3-b97b543a43b3",
                            ConcurrencyStamp = "713b1555-f10b-4a0d-8d9d-b4407e12d7a9",
                            Name = "BusController",
                            NormalizedName = "BUSCONTROLLER"
                        },
                        new
                        {
                            Id = "dbc9515d-2186-47a2-ba05-e7b06875e0f5",
                            ConcurrencyStamp = "f242d85b-eba9-462c-9edf-44f782146b3d",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole<string>");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.BusInfo", b =>
                {
                    b.Property<string>("BusNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CondNo")
                        .HasColumnType("int");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSeats")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Verified")
                        .HasColumnType("int");

                    b.HasKey("BusNo");

                    b.HasIndex("UserId");

                    b.ToTable("BusInfo");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Passenger", b =>
                {
                    b.Property<long>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Verified")
                        .HasColumnType("int");

                    b.HasKey("PId");

                    b.HasIndex("UserId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Route", b =>
                {
                    b.Property<long>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("Distance")
                        .HasColumnType("bigint");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("RNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartHolt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StartHoltId")
                        .HasColumnType("bigint");

                    b.Property<string>("StopHolt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StopHoltId")
                        .HasColumnType("bigint");

                    b.HasKey("RId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.RouteInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("Distance")
                        .HasColumnType("bigint");

                    b.Property<long>("HoltId")
                        .HasColumnType("bigint");

                    b.Property<string>("HoltName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long>("RId")
                        .HasColumnType("bigint");

                    b.Property<float>("Time")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("RouteInfo");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Session", b =>
                {
                    b.Property<long>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("BusNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("RId")
                        .HasColumnType("bigint");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Ticket", b =>
                {
                    b.Property<long>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromHalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfSeats")
                        .HasColumnType("int");

                    b.Property<long>("PId")
                        .HasColumnType("bigint");

                    b.Property<int>("PStatus")
                        .HasColumnType("int");

                    b.Property<long>("SId")
                        .HasColumnType("bigint");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToHalt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("BusNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PId")
                        .HasColumnType("bigint");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Users.UserRegistrationModel", b =>
                {
                    b.Property<string>("NIC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BusNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CondNo")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSeats")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIC");

                    b.ToTable("UserRegistrationModel");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.BusInfo", b =>
                {
                    b.HasOne("TranspotationTicketBooking.Models.Users.User", null)
                        .WithMany("BusInfos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Passenger", b =>
                {
                    b.HasOne("TranspotationTicketBooking.Models.Users.User", null)
                        .WithMany("Passengers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TranspotationTicketBooking.Models.Users.User", b =>
                {
                    b.Navigation("BusInfos");

                    b.Navigation("Passengers");
                });
#pragma warning restore 612, 618
        }
    }
}

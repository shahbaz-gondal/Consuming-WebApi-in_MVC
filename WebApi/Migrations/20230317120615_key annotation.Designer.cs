﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(AirportManagementSystemContext))]
    [Migration("20230317120615_key annotation")]
    partial class keyannotation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Booking_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("date")
                        .HasColumnName("Booking_Date");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("Customer_Id");

                    b.Property<int>("PriceId")
                        .HasColumnType("int")
                        .HasColumnName("Price_Id");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("Schedule_Id");

                    b.Property<int>("SeatId")
                        .HasColumnType("int")
                        .HasColumnName("Seat_Id");

                    b.HasKey("BookingId")
                        .HasName("PK__Bookings__35ABFDC05605A1B7");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PriceId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SeatId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Company_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Company_Name");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Company_Type");

                    b.HasKey("CompanyId")
                        .HasName("PK__Companie__5F5D191211FFA4CE");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebApi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Customer_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Customer_Name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__8CB286990BAB694B");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApi.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Flight_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("Company_Id");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Flight_Name");

                    b.Property<int>("FlightSize")
                        .HasColumnType("int")
                        .HasColumnName("Flight_Size");

                    b.HasKey("FlightId")
                        .HasName("PK__Flights__CAC1E4AFD6741366");

                    b.HasIndex("CompanyId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("WebApi.Models.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Price_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceId"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Fare")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("Flight_Id");

                    b.HasKey("PriceId")
                        .HasName("PK__Prices__A4821BD2C3879DDB");

                    b.HasIndex("FlightId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("WebApi.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Schedule_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("time")
                        .HasColumnName("Arrival_Time");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("time")
                        .HasColumnName("Departure_Time");

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("Flight_Id");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ScheduleId")
                        .HasName("PK__Schedule__8C4D3C5B03CA42D6");

                    b.HasIndex("FlightId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("WebApi.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Seat_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("Flight_Id");

                    b.Property<string>("SeatNum")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Seat_Num");

                    b.Property<string>("SeatStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Seat_Status");

                    b.HasKey("SeatId")
                        .HasName("PK__Seats__8B2CE6564F4D64A3");

                    b.HasIndex("FlightId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("WebApi.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Staff_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("Company_Id");

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("Flight_Id");

                    b.Property<string>("StaffContact")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Staff_Contact");

                    b.Property<string>("StaffGender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Staff_Gender");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Staff_Name");

                    b.Property<string>("StaffPosition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Staff_Position");

                    b.HasKey("StaffId")
                        .HasName("PK__Staff__32D1F42396F2F61E");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FlightId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("WebApi.Models.Booking", b =>
                {
                    b.HasOne("WebApi.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__Custom__05D8E0BE");

                    b.HasOne("WebApi.Models.Price", "Price")
                        .WithMany("Bookings")
                        .HasForeignKey("PriceId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__Price___02FC7413");

                    b.HasOne("WebApi.Models.Schedule", "Schedule")
                        .WithMany("Bookings")
                        .HasForeignKey("ScheduleId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__Schedu__02084FDA");

                    b.HasOne("WebApi.Models.Seat", "Seat")
                        .WithMany("Bookings")
                        .HasForeignKey("SeatId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__Seat_I__03F0984C");

                    b.Navigation("Customer");

                    b.Navigation("Price");

                    b.Navigation("Schedule");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("WebApi.Models.Flight", b =>
                {
                    b.HasOne("WebApi.Models.Company", "Company")
                        .WithMany("Flights")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Flights__Company__44FF419A");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApi.Models.Price", b =>
                {
                    b.HasOne("WebApi.Models.Flight", "Flight")
                        .WithMany("Prices")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__Prices__Flight_I__47DBAE45");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("WebApi.Models.Schedule", b =>
                {
                    b.HasOne("WebApi.Models.Flight", "Flight")
                        .WithMany("Schedules")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__Schedules__Fligh__46E78A0C");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("WebApi.Models.Seat", b =>
                {
                    b.HasOne("WebApi.Models.Flight", "Flight")
                        .WithMany("Seats")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__Seats__Flight_Id__7C4F7684");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("WebApi.Models.Staff", b =>
                {
                    b.HasOne("WebApi.Models.Company", "Company")
                        .WithMany("Staff")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Staff__Company_I__440B1D61");

                    b.HasOne("WebApi.Models.Flight", "Flight")
                        .WithMany("Staff")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__Staff__Flight_Id__45F365D3");

                    b.Navigation("Company");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("WebApi.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("WebApi.Models.Flight", b =>
                {
                    b.Navigation("Prices");

                    b.Navigation("Schedules");

                    b.Navigation("Seats");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("WebApi.Models.Price", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("WebApi.Models.Schedule", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("WebApi.Models.Seat", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}

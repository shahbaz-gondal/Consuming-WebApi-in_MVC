using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class AirportManagementSystemContext : DbContext
{
    public AirportManagementSystemContext()
    {
    }

    public AirportManagementSystemContext(DbContextOptions<AirportManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=CRIBL-SHAHFMUH1; database=AirportManagementSystem; trusted_connection=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__35ABFDC05605A1B7");

            entity.Property(e => e.BookingId).HasColumnName("Booking_Id");
            entity.Property(e => e.BookingDate)
                .HasColumnType("date")
                .HasColumnName("Booking_Date");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.PriceId).HasColumnName("Price_Id");
            entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");
            entity.Property(e => e.SeatId).HasColumnName("Seat_Id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Custom__05D8E0BE");

            entity.HasOne(d => d.Price).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Price___02FC7413");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Schedu__02084FDA");

            entity.HasOne(d => d.Seat).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Seat_I__03F0984C");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Companie__5F5D191211FFA4CE");

            entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
            entity.Property(e => e.CompanyType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Company_Type");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB286990BAB694B");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__CAC1E4AFD6741366");

            entity.Property(e => e.FlightId).HasColumnName("Flight_Id");
            entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
            entity.Property(e => e.FlightName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Flight_Name");
            entity.Property(e => e.FlightSize).HasColumnName("Flight_Size");

            entity.HasOne(d => d.Company).WithMany(p => p.Flights)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Flights__Company__44FF419A");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__Prices__A4821BD2C3879DDB");

            entity.Property(e => e.PriceId).HasColumnName("Price_Id");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FlightId).HasColumnName("Flight_Id");

            entity.HasOne(d => d.Flight).WithMany(p => p.Prices)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__Flight_I__47DBAE45");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__8C4D3C5B03CA42D6");

            entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");
            entity.Property(e => e.ArrivalTime).HasColumnName("Arrival_Time");
            entity.Property(e => e.DepartureTime).HasColumnName("Departure_Time");
            entity.Property(e => e.FlightId).HasColumnName("Flight_Id");
            entity.Property(e => e.FromCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToCity)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Flight).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedules__Fligh__46E78A0C");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seats__8B2CE6564F4D64A3");

            entity.Property(e => e.SeatId).HasColumnName("Seat_Id");
            entity.Property(e => e.FlightId).HasColumnName("Flight_Id");
            entity.Property(e => e.SeatNum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Seat_Num");
            entity.Property(e => e.SeatStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Seat_Status");

            entity.HasOne(d => d.Flight).WithMany(p => p.Seats)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seats__Flight_Id__7C4F7684");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__32D1F42396F2F61E");

            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
            entity.Property(e => e.FlightId).HasColumnName("Flight_Id");
            entity.Property(e => e.StaffContact)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Staff_Contact");
            entity.Property(e => e.StaffGender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Staff_Gender");
            entity.Property(e => e.StaffName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Staff_Name");
            entity.Property(e => e.StaffPosition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Staff_Position");

            entity.HasOne(d => d.Company).WithMany(p => p.Staff)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__Company_I__440B1D61");

            entity.HasOne(d => d.Flight).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__Flight_Id__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

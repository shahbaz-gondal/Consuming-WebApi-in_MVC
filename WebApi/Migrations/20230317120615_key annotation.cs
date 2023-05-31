using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class keyannotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Company_Type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Companie__5F5D191211FFA4CE", x => x.Company_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__8CB286990BAB694B", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Flight_Size = table.Column<int>(type: "int", nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Flights__CAC1E4AFD6741366", x => x.Flight_Id);
                    table.ForeignKey(
                        name: "FK__Flights__Company__44FF419A",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "Company_Id");
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Price_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prices__A4821BD2C3879DDB", x => x.Price_Id);
                    table.ForeignKey(
                        name: "FK__Prices__Flight_I__47DBAE45",
                        column: x => x.Flight_Id,
                        principalTable: "Flights",
                        principalColumn: "Flight_Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Schedule_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ToCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Departure_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Arrival_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__8C4D3C5B03CA42D6", x => x.Schedule_Id);
                    table.ForeignKey(
                        name: "FK__Schedules__Fligh__46E78A0C",
                        column: x => x.Flight_Id,
                        principalTable: "Flights",
                        principalColumn: "Flight_Id");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Seat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seat_Num = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Seat_Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Seats__8B2CE6564F4D64A3", x => x.Seat_Id);
                    table.ForeignKey(
                        name: "FK__Seats__Flight_Id__7C4F7684",
                        column: x => x.Flight_Id,
                        principalTable: "Flights",
                        principalColumn: "Flight_Id");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Staff_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Staff_Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Staff_Contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Staff_Position = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__32D1F42396F2F61E", x => x.Staff_Id);
                    table.ForeignKey(
                        name: "FK__Staff__Company_I__440B1D61",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK__Staff__Flight_Id__45F365D3",
                        column: x => x.Flight_Id,
                        principalTable: "Flights",
                        principalColumn: "Flight_Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Schedule_Id = table.Column<int>(type: "int", nullable: false),
                    Price_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Seat_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookings__35ABFDC05605A1B7", x => x.Booking_Id);
                    table.ForeignKey(
                        name: "FK__Bookings__Custom__05D8E0BE",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                    table.ForeignKey(
                        name: "FK__Bookings__Price___02FC7413",
                        column: x => x.Price_Id,
                        principalTable: "Prices",
                        principalColumn: "Price_Id");
                    table.ForeignKey(
                        name: "FK__Bookings__Schedu__02084FDA",
                        column: x => x.Schedule_Id,
                        principalTable: "Schedules",
                        principalColumn: "Schedule_Id");
                    table.ForeignKey(
                        name: "FK__Bookings__Seat_I__03F0984C",
                        column: x => x.Seat_Id,
                        principalTable: "Seats",
                        principalColumn: "Seat_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Customer_Id",
                table: "Bookings",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Price_Id",
                table: "Bookings",
                column: "Price_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Schedule_Id",
                table: "Bookings",
                column: "Schedule_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Seat_Id",
                table: "Bookings",
                column: "Seat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Company_Id",
                table: "Flights",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Flight_Id",
                table: "Prices",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Flight_Id",
                table: "Schedules",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Flight_Id",
                table: "Seats",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Company_Id",
                table: "Staff",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Flight_Id",
                table: "Staff",
                column: "Flight_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

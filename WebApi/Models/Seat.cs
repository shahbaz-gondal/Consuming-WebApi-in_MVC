using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Seat
{
    public int SeatId { get; set; }

    public string SeatNum { get; set; } = null!;

    public string SeatStatus { get; set; } = null!;

    public int FlightId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Flight Flight { get; set; } = null!;
}

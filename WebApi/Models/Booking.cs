using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public DateTime BookingDate { get; set; }

    public int ScheduleId { get; set; }

    public int PriceId { get; set; }

    public int UserId { get; set; }

    public int SeatId { get; set; }

    public virtual Price Price { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

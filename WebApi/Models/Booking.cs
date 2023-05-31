using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public partial class Booking
{
    [Key]
    public int BookingId { get; set; }

    public DateTime BookingDate { get; set; }

    public int ScheduleId { get; set; }

    public int PriceId { get; set; }

    public int CustomerId { get; set; }

    public int SeatId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Price Price { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public partial class Schedule
{
    [Key]
    public int ScheduleId { get; set; }

    public string FromCity { get; set; } = null!;

    public string ToCity { get; set; } = null!;

    public TimeSpan DepartureTime { get; set; }

    public TimeSpan ArrivalTime { get; set; }

    public int FlightId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Flight Flight { get; set; } = null!;
}

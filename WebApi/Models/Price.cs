using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Price
{
    public int PriceId { get; set; }

    public string Class { get; set; } = null!;

    public int Fare { get; set; }

    public int FlightId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Flight Flight { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public partial class Price
{
    [Key]
    public int PriceId { get; set; }

    public string Class { get; set; } = null!;

    public int Fare { get; set; }

    public int FlightId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Flight Flight { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public string FlightName { get; set; } = null!;

    public int FlightSize { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

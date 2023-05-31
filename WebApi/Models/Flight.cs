using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public partial class Flight
{
    [Key]
    public int FlightId { get; set; }

    public string FlightName { get; set; }

    public int FlightSize { get; set; }

    public int CompanyId { get; set; }
    
    public virtual Company Company { get; set; }

    public virtual ICollection<Price> Prices { get; } = new List<Price>();

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public virtual ICollection<Seat> Seats { get; } = new List<Seat>();

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}

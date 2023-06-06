using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyType { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

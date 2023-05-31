using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public partial class Company
{
    [Key]
    public int CompanyId { get; set; }

    public string CompanyName { get; set; }

    public string CompanyType { get; set; }

    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string Contact { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}

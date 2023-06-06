using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string Contact { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

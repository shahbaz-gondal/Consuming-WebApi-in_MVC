using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string StaffGender { get; set; } = null!;

    public string StaffContact { get; set; } = null!;

    public string StaffPosition { get; set; } = null!;

    public int? CompanyId { get; set; }

    public int? FlightId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Flight? Flight { get; set; }
}

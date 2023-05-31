using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Models;

public partial class Staff
{
    [Key]
    public int StaffId { get; set; }

    public string StaffName { get; set; }

    public string StaffGender { get; set; }

    public string StaffContact { get; set; }

    public string StaffPosition { get; set; }

    public int CompanyId { get; set; }

    public int FlightId { get; set; }

    public virtual Company Company { get; set; }

    public virtual Flight Flight { get; set; }
}

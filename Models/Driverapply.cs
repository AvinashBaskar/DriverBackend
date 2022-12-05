using System;
using System.Collections.Generic;

namespace BEdotnetdrive.Models;

public partial class Driverapply
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? LicenseNo { get; set; }

    public string? WorkExperience { get; set; }

    public string? OwnorRent { get; set; }

    public string? DriverAddress { get; set; }
}

using System;
using System.Collections.Generic;

namespace KoiProject.WebApplication.Entities;

public partial class KoiCheckIn
{
    public int CheckInId { get; set; }

    public int KoiId { get; set; }

    public DateTime? CheckInTime { get; set; }

    public string HealthStatus { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual KoiManagement Koi { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class KoiManagement
{
    public int KoiId { get; set; }

    public string Name { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public decimal Size { get; set; }

    public string? Color { get; set; }

    public DateOnly? DateOfEntry { get; set; }

    public string? Origin { get; set; }

    public decimal? Price { get; set; }

    public string? HealthStatus { get; set; }

    public string UserEmail { get; set; } = null!;

    public decimal Gpa { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual User UserEmailNavigation { get; set; } = null!;
}

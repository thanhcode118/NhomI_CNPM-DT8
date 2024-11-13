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

    public string user_email { get; set; } = null!;

    public decimal Gpa { get; set; }

    public int? id_user { get; set; }

    public int VoteCount { get; set; }

    public virtual User UserEmailNavigation { get; set; } = null!;

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}

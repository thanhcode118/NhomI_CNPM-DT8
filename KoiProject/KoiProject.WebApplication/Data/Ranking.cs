using System;
using System.Collections.Generic;

namespace KoiProject.WebApplication.Data;

public partial class Ranking
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public int? Votes { get; set; }
}

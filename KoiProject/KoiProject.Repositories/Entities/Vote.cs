using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class Vote
{
    public int VoteId { get; set; }

    public int KoiId { get; set; }

    public string VoterEmail { get; set; } = null!;

    public DateTime? VoteDate { get; set; }

    public virtual KoiManagement Koi { get; set; } = null!;

    public virtual User VoterEmailNavigation { get; set; } = null!;
}

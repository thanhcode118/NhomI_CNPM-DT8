using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class Member
{
    public int MemberId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}

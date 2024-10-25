using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KOI_Competition.Models;

namespace KOI_Competition.Data
{
    public class KOI_CompetitionContext : DbContext
    {
        public KOI_CompetitionContext (DbContextOptions<KOI_CompetitionContext> options)
            : base(options)
        {
        }

        public DbSet<KOI_Competition.Models.User> User { get; set; } = default!;
    }
}

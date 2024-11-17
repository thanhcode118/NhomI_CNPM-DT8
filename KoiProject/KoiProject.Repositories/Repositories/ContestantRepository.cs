using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Repositories
{
    public class ContestantRepository : IContestantRepository
    {
        private readonly KoiCompetitionContext   _context;

        public ContestantRepository(KoiCompetitionContext context)
        {
            _context = context;
        }

        public async Task<List<KoiManagement>> GetAvailableKoiAsync()
        {
            return await _context.KoiManagements
                .Where(k => k.HealthStatus == "Healthy" )
                .ToListAsync();
        }

        public async Task<bool> SaveContestantAsync(Contestant contestant)
        {
            _context.Contestants.Add(contestant);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}

using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Repositories
{
    public class ContestantRepository : IContestantRepository
    {
        private readonly KoiCompetitionContext _context;

        public ContestantRepository(KoiCompetitionContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveKoiAsync(KoiManagement koi)
        {
            _context.KoiManagements.Add(koi);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

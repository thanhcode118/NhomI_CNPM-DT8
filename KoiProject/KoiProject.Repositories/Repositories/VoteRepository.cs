using KoiProject.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class VoteRepository : IVoteRepository
{
    private readonly KoiCompetitionContext _context;

    public VoteRepository(KoiCompetitionContext context)
    {
        _context = context;
    }

    public async Task<IList<KoiManagement>> GetAllKoiAsync()
    {
        return await _context.KoiManagements.ToListAsync() as IList<KoiManagement>;
    }


    public Task<KoiManagement> GetKoiByIdAsync(int koiID)
    {
        return _context.KoiManagements.FirstOrDefaultAsync(k => k.KoiId == koiID);
    }

    public Task<Vote> GetVoteByEmailAndKoiIdAsync(string email, int koiID)
    {
        return _context.Votes.FirstOrDefaultAsync(v => v.VoterEmail == email && v.KoiId == koiID);
    }


    public async Task AddVoteAsync(Vote vote)
    {
        await _context.Votes.AddAsync(vote);
    }

    public Task UpdateKoiAsync(KoiManagement koi)
    {
        _context.KoiManagements.Update(koi);
        return _context.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}

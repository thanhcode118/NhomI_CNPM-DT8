using KoiProject.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        return await _context.KoiManagements.ToListAsync();
    }

    public async Task<KoiManagement> GetKoiByIdAsync(int koiId)
    {
        return await _context.KoiManagements.FindAsync(koiId);
    }

    public async Task AddVoteAsync(Vote vote)
    {
        _context.Votes.Add(vote);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
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

//public class VoteRepository : IVoteRepository
//{
    //private readonly KoiCompetitionContext _context;

    //public VoteRepository(KoiCompetitionContext context)
    //{
        //_context = context;
    //}

    //public async Task<IList<KoiManagement>> GetAllKoiAsync()
    //{
        //return await _context.KoiFish.ToListAsync() as IList<KoiManagement>;
    //}


    //public Task<KoiManagement> GetKoiByIdAsync(int koiId)
    //{
        //return _context.KoiFish.FirstOrDefaultAsync(k => k.KoiId == koiId);
    //}

    //public Task<Vote> GetVoteByEmailAndKoiIdAsync(string email, int koiId)
    //{
        //return _context.Votes.FirstOrDefaultAsync(v => v.VoterEmail == email && v.KoiID == koiId);
    //}


    //public async Task AddVoteAsync(Vote vote)
    //{
        //await _context.Votes.AddAsync(vote);
    //}

    //public Task UpdateKoiAsync(KoiManagement koi)
    //{
        //_context.KoiFish.Update(koi);
        //return _context.SaveChangesAsync();
    //}

    //public Task SaveChangesAsync()
    //{
        //return _context.SaveChangesAsync();
    //}
//}

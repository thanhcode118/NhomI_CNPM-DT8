using KoiProject.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;

    public VoteService(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public Task<IList<KoiManagement>> GetAllKoiAsync()
    {
        return  _voteRepository.GetAllKoiAsync();
    }

    public async Task<bool> VoteForKoiAsync(int koiId, string voterEmail)
    {
        var koi = await _voteRepository.GetKoiByIdAsync(koiId);
        if (koi != null)
        {
            var vote = new Vote { KoiID = koiId, VoterEmail = voterEmail };
            await _voteRepository.AddVoteAsync(vote);

            // Tăng VoteCount trong KoiManagement
            koi.VoteCount += 1;
            await _voteRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

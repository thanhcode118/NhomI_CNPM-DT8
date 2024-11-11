using KoiProject.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IVoteService
{
    Task<IList<KoiManagement>> GetAllKoiAsync();
    Task<bool> VoteForKoiAsync(int koiId, string voterEmail);
    Task<bool> IncreaseVoteAsync(int koiId);
}

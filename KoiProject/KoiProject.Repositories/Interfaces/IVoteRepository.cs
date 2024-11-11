using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IVoteRepository
{
    Task<IList<KoiManagement>> GetAllKoiAsync();
    Task<KoiManagement> GetKoiByIdAsync(int koiId);
    Task<Vote> GetVoteByEmailAndKoiIdAsync(string email, int koiId);
    Task AddVoteAsync(Vote vote);
    Task UpdateKoiAsync(KoiManagement koi);
    Task SaveChangesAsync();
}

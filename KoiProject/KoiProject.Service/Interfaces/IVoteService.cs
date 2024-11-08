using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IVoteService
{
    Task<bool> VoteForKoiAsync(int koiId, string voterEmail);
    Task<IList<KoiManagement>> GetAllKoiAsync();
}

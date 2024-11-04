using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;

namespace KoiProject.Repositories.Interfaces
{
    public interface IRankingRepository
    {
        Task<List<Ranking>> GetAllRankingsAsync();
        Task<Ranking> GetRankingByIdAsync(int id);
        Task<bool> IsUserInRankingAsync(string username);
        Task AddRankingAsync(Ranking ranking);
        Task UpdateRankingAsync(Ranking ranking);
        Task DeleteRankingAsync(int id);
    }
}

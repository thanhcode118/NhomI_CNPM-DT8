using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;

namespace KoiProject.Services.Interfaces
{
    public interface IRankingService
    {
        Task<List<Ranking>> GetAllRankingsAsync();
        Task<Ranking> GetRankingByIdAsync(int id);
        Task AddRankingAsync(Ranking ranking);
        Task UpdateRankingAsync(Ranking ranking);
        Task DeleteRankingAsync(int id);
    }
}

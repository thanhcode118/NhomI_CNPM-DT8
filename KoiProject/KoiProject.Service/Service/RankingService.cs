using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Services.Interfaces;

namespace KoiProject.Services
{
    public class RankingService : IRankingService
    {
        private readonly IRankingRepository _rankingRepository;

        public RankingService(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        public async Task<List<Ranking>> GetAllRankingsAsync()
        {
            return await _rankingRepository.GetAllRankingsAsync();
        }

        public async Task<Ranking> GetRankingByIdAsync(int id)
        {
            return await _rankingRepository.GetRankingByIdAsync(id);
        }

        public async Task AddRankingAsync(Ranking ranking)
        {
            await _rankingRepository.AddRankingAsync(ranking);
        }

        public async Task UpdateRankingAsync(Ranking ranking)
        {
            await _rankingRepository.UpdateRankingAsync(ranking);
        }

        public async Task DeleteRankingAsync(int id)
        {
            await _rankingRepository.DeleteRankingAsync(id);
        }
    }
}

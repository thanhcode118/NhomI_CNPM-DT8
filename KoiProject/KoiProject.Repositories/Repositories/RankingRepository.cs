using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Repositories
{
    public class RankingRepository : IRankingRepository
    {
        private readonly KoiCompetitionContext _context;

        public RankingRepository(KoiCompetitionContext context)
        {
            _context = context;
        }

        // Lấy danh sách xếp hạng được sắp xếp theo điểm số
        public async Task<List<Ranking>> GetAllRankingsAsync()
        {
            return await _context.Rankings
                                 .OrderByDescending(r => r.Score)
                                 .ToListAsync();
        }

        // Lấy thông tin xếp hạng của người dùng dựa trên ID
        public async Task<Ranking> GetRankingByIdAsync(int id)
        {
            return await _context.Rankings
                                 .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Kiểm tra xem người dùng có trong bảng xếp hạng chưa dựa trên tên
        public async Task<bool> IsUserInRankingAsync(string username)
        {
            return await _context.Rankings.AnyAsync(r => r.UserName == username);
        }

        // Thêm người dùng mới vào bảng xếp hạng
        public async Task AddRankingAsync(Ranking ranking)
        {
            _context.Rankings.Add(ranking);
            await _context.SaveChangesAsync();
        }

        // Cập nhật thông tin xếp hạng của người dùng
        public async Task UpdateRankingAsync(Ranking ranking)
        {
            _context.Rankings.Update(ranking);
            await _context.SaveChangesAsync();
        }

        // Xóa thông tin xếp hạng của người dùng dựa trên ID
        public async Task DeleteRankingAsync(int id)
        {
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking != null)
            {
                _context.Rankings.Remove(ranking);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Ranking>> GetRankingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

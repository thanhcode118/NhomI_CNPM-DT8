using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Repositories
{
    public class KoiManagementRepository : IKoiManagementRepository
    {
        private readonly KoiCompetitionContext _context;

        public KoiManagementRepository(KoiCompetitionContext context)
        {
            _context = context;
        }

        public async Task<KoiManagement> AddKoiAsync(KoiManagement koi)
        {
            _context.KoiManagements.Add(koi);
            await _context.SaveChangesAsync();
            return koi;
        }

        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            var koi = await _context.KoiManagements.FindAsync(koiId);
            if (koi == null) return false;

            _context.KoiManagements.Remove(koi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<KoiManagement> UpdateKoiAsync(KoiManagement koi)
        {
            _context.KoiManagements.Update(koi);
            await _context.SaveChangesAsync();
            return koi;
        }

        public async Task<KoiManagement?> GetKoiByIdAsync(int koiId)
        {
            return await _context.KoiManagements.FindAsync(koiId);
        }



       


        public async Task<IEnumerable<KoiManagement>> GetAllKoisAsync()
        {
            try
            {
                var results = await _context.KoiManagements
                                            .Include(k => k.UserEmailNavigation)
                                            .ToListAsync();

                return results; // Không cần `?? new List<KoiManagement>()` vì `ToListAsync` không trả về null.
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (hoặc sử dụng framework ghi log)
                Console.Error.WriteLine($"Error in GetAllKoisAsync: {ex.Message}");
                throw;
            }
        }
        public async Task<List<KoiManagement>> GetKoisForUserAsync(int? userId = null, string email = null)
        {
            if (userId == null && string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Either userId or email must be provided.");
            }

            // Ưu tiên tìm bằng userId nếu có
            if (userId.HasValue)
            {
                return await _context.KoiManagements
                                     .Where(k => k.IdUser == userId.Value)
                                     .ToListAsync();
            }

            // Nếu không có userId, tìm bằng email
            return await _context.KoiManagements
                                 .Where(k => k.UserEmail == email)
                                 .ToListAsync();
        }


    }
}

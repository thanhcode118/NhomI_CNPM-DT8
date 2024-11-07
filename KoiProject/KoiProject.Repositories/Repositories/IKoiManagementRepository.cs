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
            return await _context.KoiManagements.ToListAsync();
        }
    }
}

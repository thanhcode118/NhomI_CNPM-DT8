using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using KoiProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Service.Service
{
    public class KoiManagementService : IKoiManagementService
    {
        private readonly IKoiManagementRepository _repository;

        public KoiManagementService(IKoiManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<KoiManagement> AddKoiAsync(KoiManagement koi)
        {
            return await _repository.AddKoiAsync(koi);
        }

        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            return await _repository.DeleteKoiAsync(koiId);
        }

        public async Task<KoiManagement> UpdateKoiAsync(KoiManagement koi)
        {
            return await _repository.UpdateKoiAsync(koi);
        }

        public async Task<KoiManagement?> GetKoiByIdAsync(int koiId)
        {
            return await _repository.GetKoiByIdAsync(koiId);
        }

        public async Task<IEnumerable<KoiManagement>> GetAllKoisAsync()
        {
            return await _repository.GetAllKoisAsync();
        }

        public async Task<List<KoiManagement>> GetKoisForLoggedInUserAsync(int? userId = null, string email = null)
        {
            return await _repository.GetKoisForUserAsync(userId, email);
        }

    }
}


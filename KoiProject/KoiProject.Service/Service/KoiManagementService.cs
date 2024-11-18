using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Service.Interfaces;

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

        public async Task<List<KoiManagement>> GetAllKoiAsync()
        {
            return await _repository.GetAllKoiAsync();  // Gọi phương thức từ repository để lấy tất cả cá Koi
        }


        public async Task<KoiManagement?> GetKoiByIdAsync(int koiId)
        {
            return await _repository.GetKoiByIdAsync(koiId);
        }

        public async Task<IEnumerable<KoiManagement>> GetAllKoisAsync()
        {
            return await _repository.GetAllKoisAsync();
        }

        public async Task<List<KoiManagement>> GetKoisForLoggedInUserAsync(int? userId, string email)
        {
            // Gọi phương thức từ Repository
            return await _repository.GetKoisForUserAsync(userId, email);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _repository.GetUserByEmailAsync(email);
        }

    }
}

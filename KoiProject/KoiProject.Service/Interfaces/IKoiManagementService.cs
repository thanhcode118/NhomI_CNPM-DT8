using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Service.Interfaces
{
    public  interface IKoiManagementService
    {
        // Thêm một Koi mới
        Task<KoiManagement> AddKoiAsync(KoiManagement koi);

        // Xóa một Koi theo ID
        Task<bool> DeleteKoiAsync(int koiId);

        // Cập nhật thông tin Koi
        Task<KoiManagement> UpdateKoiAsync(KoiManagement koi);

        // Lấy thông tin một Koi theo ID
        Task<KoiManagement?> GetKoiByIdAsync(int koiId);

        // Lấy danh sách tất cả các Koi
        Task<IEnumerable<KoiManagement>> GetAllKoisAsync();
        Task<List<KoiManagement>> GetKoisForLoggedInUserAsync(int? userId = null, string email = null);
    }
}

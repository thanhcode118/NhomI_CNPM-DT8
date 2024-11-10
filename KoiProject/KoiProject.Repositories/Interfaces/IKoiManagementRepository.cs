using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Interfaces
{
    public interface IKoiManagementRepository
    {
        // Thêm một đối tượng Koi
        Task<KoiManagement> AddKoiAsync(KoiManagement koi);

        // Xóa một đối tượng Koi theo ID
        Task<bool> DeleteKoiAsync(int koiId);

        // Cập nhật thông tin của đối tượng Koi
        Task<KoiManagement> UpdateKoiAsync(KoiManagement koi);

        // Lấy một đối tượng Koi theo ID
        Task<KoiManagement?> GetKoiByIdAsync(int koiId);

        // Lấy tất cả các đối tượng Koi
        Task<IEnumerable<KoiManagement>> GetAllKoisAsync();

        // Lấy tất cả các đối tượng Koi theo emial
        Task<List<KoiManagement>> GetKoisForUserAsync(int? userId = null, string email = null);
    }
}

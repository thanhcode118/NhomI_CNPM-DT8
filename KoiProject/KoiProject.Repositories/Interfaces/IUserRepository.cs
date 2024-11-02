using System.Threading.Tasks;
using KoiProject.Repositories.Entities;

namespace KoiProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string hashedPassword); // Lấy người dùng theo email và mật khẩu mã hóa
        Task<bool> IsUsernameTakenAsync(string username); // Kiểm tra trùng lặp tên người dùng
        Task<bool> IsEmailTakenAsync(string email); // Kiểm tra trùng lặp email
        Task AddUserAsync(User user); // Thêm người dùng mới
    }
}

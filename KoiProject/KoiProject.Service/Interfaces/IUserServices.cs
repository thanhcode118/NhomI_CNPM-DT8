using System.Threading.Tasks;
using KoiProject.Repositories.Entities;

namespace KoiProject.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user); // Đăng ký người dùng mới
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password); // Đăng nhập người dùng
        Task<bool> IsUsernameTakenAsync(string username); // Kiểm tra trùng lặp tên người dùng
        Task<bool> IsEmailTakenAsync(string email); // Kiểm tra trùng lặp email
    }
}

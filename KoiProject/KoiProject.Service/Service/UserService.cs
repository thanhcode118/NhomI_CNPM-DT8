// UserService.cs
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace KoiProject.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
            user.Password = HashPassword(user.Password);
            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            // Mã hóa mật khẩu người dùng đã nhập trước khi so sánh
            var hashedPassword = HashPassword(password);
            return await _userRepository.GetUserByEmailAndPasswordAsync(email, hashedPassword);
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _userRepository.IsUsernameTakenAsync(username);
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _userRepository.IsEmailTakenAsync(email);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

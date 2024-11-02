using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiCompetitionContext _context;

        public UserRepository(KoiCompetitionContext context)
        {
            _context = context;
        }

        // Truy vấn người dùng dựa trên email và mật khẩu đã mã hóa
        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string hashedPassword)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);
        }

        // Kiểm tra xem tên người dùng đã tồn tại trong cơ sở dữ liệu hay chưa
        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Name == username);
        }

        // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu hay chưa
        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        // Thêm người dùng mới vào cơ sở dữ liệu
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}

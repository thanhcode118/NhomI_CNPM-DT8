using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Cryptography;
using System.Text;
using KoiProject.Repositories.Data;

public class AccountController : Controller
{
    private readonly HtqlkoiContext _context;

    public AccountController(HtqlkoiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var hashedPassword = password; // Không mã hóa

        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Hashed Password: {hashedPassword}");
        var users = _context.Users.ToList();
        if (users.Any())
        {
            Console.WriteLine("Kết nối cơ sở dữ liệu thành công, đã tìm thấy người dùng.");
        }
        else
        {
            Console.WriteLine("Kết nối cơ sở dữ liệu thành công nhưng không có người dùng nào.");
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);

        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.UserId);
            return RedirectToAction("Index", "Home");
        }

        TempData["LoginError"] = "Email hoặc mật khẩu không đúng.";
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(string username, string email, string password)
    {

        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            TempData["SignUpError"] = "Email này đã được đăng ký.";
            return View();
        }

        var user = new User
        {
            Name = username,
            Email = email,
            Password = password, // Lưu mật khẩu không mã hóa để kiểm tra
            Role = "Customer" // Default role
        };

        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving user to database: " + ex.Message);
            TempData["SignUpError"] = "Có lỗi xảy ra khi đăng ký tài khoản.";
            return View();
        }

        return RedirectToAction("Login", "Account");
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

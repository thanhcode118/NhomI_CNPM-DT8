using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KoiProject.Repositories.Data;

public class LoginModel : PageModel
{
    private readonly HtqlkoiContext _context;

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public LoginModel(HtqlkoiContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Mã hóa mật khẩu người dùng đã nhập
        var hashedPassword = HashPassword(Password);

        // Tìm người dùng với email và mật khẩu đã mã hóa
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);

        if (user != null)
        {
            // Lưu ID người dùng vào session
            HttpContext.Session.SetInt32("UserId", user.UserId);

            // Điều hướng dựa trên vai trò của người dùng
            if (user.Role == "admin")
            {
                return RedirectToPage("/Dashboard"); // Điều hướng đến trang dashboard cho admin
            }
            else
            {
                return RedirectToPage("/Home"); // Điều hướng đến trang home cho member
            }
        }

        TempData["LoginError"] = "Email hoặc mật khẩu không đúng.";
        return Page();
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

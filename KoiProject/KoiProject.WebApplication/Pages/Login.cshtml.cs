using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using KoiProject.Repositories.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);
        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.UserId);
            return RedirectToPage("/dashboard"); // Redirect đến trang chính nếu đăng nhập thành công
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

using Microsoft.AspNetCore.Mvc;



using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

public class LoginModel : PageModel
{
    private readonly IUserService _userService;

    public LoginModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

   

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {

        // Mã hóa mật khẩu người dùng đã nhập
        var hashedPassword = HashPassword(Password);

        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Password (hashed): {hashedPassword}");

        // Tìm người dùng với email và mật khẩu đã mã hóa
        var user = await _userService.GetUserByEmailAndPasswordAsync(Email, hashedPassword);

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

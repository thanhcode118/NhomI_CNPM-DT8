
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.Scripting;
using KoiProject.Repositories.Entities;

namespace KoiProject.WebApplication.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly KoiCompetitionContext _context;

        public RegisterModel(KoiCompetitionContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra trùng lặp Username
            var existingUserByUsername = _context.Users.FirstOrDefault(u => u.Name == Username);
            if (existingUserByUsername != null)
            {
                ModelState.AddModelError("Username", "Tên người dùng đã tồn tại. Vui lòng chọn tên khác.");
                return Page();
            }

            // Kiểm tra trùng lặp Email
            var existingUserByEmail = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (existingUserByEmail != null)
            {
                ModelState.AddModelError("Email", "Email đã được sử dụng. Vui lòng chọn email khác.");
                return Page();
            }

            // Tạo người dùng mới và thêm vào cơ sở dữ liệu
            var user = new User
            {
                Email = Email,
                Name = Username,
                Role = "member",
                Password = Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập.";
            return RedirectToPage("/Login");
        }
    }
}
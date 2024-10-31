using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class RegisterModel : PageModel
    {
        

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra xem mật khẩu có khớp không
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            // Tạo đối tượng Member
            
            

            // Nếu đăng ký không thành công
            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return Page();
        }
    }
}

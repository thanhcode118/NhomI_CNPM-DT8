using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } // Thuộc tính để bind dữ liệu từ input username

    [BindProperty]
    public string Password { get; set; } // Thuộc tính để bind dữ liệu từ input password

    public string ErrorMessage { get; set; } // Thuộc tính để lưu thông báo lỗi

    // Phương thức GET để hiển thị trang login
    public void OnGet()
    {
        // Có thể thêm các khởi tạo nếu cần
    }

    // Phương thức POST để xử lý dữ liệu khi người dùng nhấn nút đăng nhập
    public IActionResult OnPost()
    {
        // Thực hiện kiểm tra tên đăng nhập và mật khẩu
        if (Username == "trinh" && Password == "1") // Thay thế với logic kiểm tra thực tế
        {
            // Chuyển hướng đến trang chính nếu đăng nhập thành công
            return RedirectToPage("/Index");
        }
        else
        {
            // Nếu đăng nhập thất bại, thiết lập thông báo lỗi
            ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return Page();
        }
    }
}

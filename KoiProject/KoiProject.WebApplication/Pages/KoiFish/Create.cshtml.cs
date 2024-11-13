using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;

namespace KoiProject.WebApplication.Pages.KoiFish
{
    public class CreateModel : PageModel
    {
        private readonly IKoiManagementService _koiManagementService;

        public CreateModel(IKoiManagementService koiManagementService)
        {
            _koiManagementService = koiManagementService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Sử dụng dịch vụ để lấy danh sách User Email
            ViewData["UserEmail"] = new SelectList(await _koiManagementService.GetAllKoisAsync(), "UserEmail", "UserEmail");
            return Page();
        }

        [BindProperty]
        public KoiManagement KoiManagement { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page(); // Quay lại trang nếu ModelState không hợp lệ
                }

                // Lấy thông tin từ session
                var userId = HttpContext.Session.GetInt32("UserId");
                var email = HttpContext.Session.GetString("UserEmail");

                if (userId == null || string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError(string.Empty, "User information is missing. Please log in.");
                    return RedirectToPage("/Account/Login");
                }

                // Gán thông tin từ session vào đối tượng KoiManagement
                KoiManagement.IdUser = userId.Value;
                KoiManagement.UserEmail = email;

                // Thêm cá Koi thông qua dịch vụ
                await _koiManagementService.AddKoiAsync(KoiManagement);

                // Chuyển hướng về trang Index sau khi thêm thành công
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while adding Koi: {ex.Message}");
                // Gán thông báo lỗi nếu cần
                ModelState.AddModelError(string.Empty, "An error occurred while adding the Koi.");
                return Page(); // Quay lại trang với lỗi
            }
        }


    }
}

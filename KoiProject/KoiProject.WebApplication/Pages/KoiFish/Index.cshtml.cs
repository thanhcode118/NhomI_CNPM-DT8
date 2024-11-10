using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;

namespace KoiProject.WebApplication.Pages.KoiFish
{
    public class IndexModel : PageModel
    {
        private readonly IKoiManagementService _koiManagementService;

        public IndexModel(IKoiManagementService koiManagementService)
        {
            _koiManagementService = koiManagementService;
        }

        public IList<KoiManagement> KoiManagementByEmail { get; private set; } = new List<KoiManagement>();

        public async Task OnGetAsync()
        {
            try
            {
                // Lấy thông tin từ session
                var userId = HttpContext.Session.GetInt32("UserId");
                var email = HttpContext.Session.GetString("UserEmail");

                if (userId == null && string.IsNullOrWhiteSpace(email))
                {
                    RedirectToPage("/Account/Login"); // Chuyển hướng nếu không tìm thấy thông tin người dùng
                    return;
                }

                // Lấy danh sách cá Koi theo userId hoặc email
                KoiManagementByEmail = await _koiManagementService.GetKoisForLoggedInUserAsync(userId, email);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                KoiManagementByEmail = new List<KoiManagement>(); // Gán danh sách rỗng nếu xảy ra lỗi
            }
        }
    }

}

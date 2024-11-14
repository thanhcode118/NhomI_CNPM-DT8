using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using KoiProject.Service;

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
        public KoiManagement Model { get; set; } // Thuộc tính Model dùng để bind dữ liệu từ View


        public async Task<IActionResult> OnPostAsync()
        {
            var userEmail = HttpContext.Session.GetString("emial");

            if (string.IsNullOrWhiteSpace(userEmail))
            {
                return RedirectToPage("/Login");
            }

            // Lấy thông tin người dùng
            var user = await _koiManagementService.GetUserByEmailAsync(userEmail);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Không tìm thấy thông tin người dùng.");
                return Page();
            }
            if (Model == null)
            {
                Model = new KoiManagement();
            }


            // Gán đối tượng User vào UserEmailNavigation
            Model.UserEmailNavigation = user;

            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    var key = state.Key; // Tên thuộc tính
                    var errors = state.Value.Errors; // Danh sách lỗi

                    foreach (var error in errors)
                    {
                        // Log hoặc ghi ra console lỗi
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }


            // Lưu cá Koi vào cơ sở dữ liệu
            await _koiManagementService.AddKoiAsync(Model);

            return RedirectToPage("./Index");
        }
    }
}

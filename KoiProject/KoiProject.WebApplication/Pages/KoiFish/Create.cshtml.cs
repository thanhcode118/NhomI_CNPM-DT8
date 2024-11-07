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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _koiManagementService.AddKoiAsync(KoiManagement);

            return RedirectToPage("./Index");
        }
    }

}

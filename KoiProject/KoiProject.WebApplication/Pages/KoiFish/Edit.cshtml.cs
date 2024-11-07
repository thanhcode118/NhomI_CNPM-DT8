using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;

namespace KoiProject.WebApplication.Pages.KoiFish
{
    public class EditModel : PageModel
    {
        private readonly IKoiManagementService _koiManagementService;

        public EditModel(IKoiManagementService koiManagementService)
        {
            _koiManagementService = koiManagementService;
        }

        [BindProperty]
        public KoiManagement KoiManagement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Sử dụng service để lấy thông tin Koi dựa trên ID
            var koimanagement = await _koiManagementService.GetKoiByIdAsync(id.Value);
            if (koimanagement == null)
            {
                return NotFound();
            }

            KoiManagement = koimanagement;
            ViewData["UserEmail"] = new SelectList(await _koiManagementService.GetAllKoisAsync(), "UserEmail", "UserEmail");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _koiManagementService.UpdateKoiAsync(KoiManagement);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await KoiManagementExists(KoiManagement.KoiId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> KoiManagementExists(int id)
        {
            var koi = await _koiManagementService.GetKoiByIdAsync(id);
            return koi != null;
        }
    }

}

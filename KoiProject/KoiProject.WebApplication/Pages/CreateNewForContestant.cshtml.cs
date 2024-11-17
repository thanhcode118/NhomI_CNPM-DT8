using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CreateNewForContestantModel : PageModel
{
    private readonly IContestantService _contestantService;

    public CreateNewForContestantModel(IContestantService contestantService)
    {
        _contestantService = contestantService;
    }

    public List<KoiManagement> KoiList { get; set; } = new List<KoiManagement>();   

    [BindProperty]
    public Contestant Contestant { get; set; }

    public async Task OnGetAsync()
    {
        KoiList = await _contestantService.GetAvailableKoiAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Xử lý khi dữ liệu không hợp lệ
            ModelState.AddModelError(string.Empty, "Thông tin không hợp lệ. Vui lòng kiểm tra lại!");
            return Page();
        }

        try
        {
            var success = await _contestantService.RegisterContestantAsync(Contestant);
            if (success)
            {
                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return RedirectToPage("CreateNewForContestant");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi lưu thông tin.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Lỗi: {ex.Message}");
        }

        return Page();
    }

}

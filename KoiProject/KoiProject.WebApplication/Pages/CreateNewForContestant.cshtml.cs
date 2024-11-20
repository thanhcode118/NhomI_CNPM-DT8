using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateNewContestantModel : PageModel
{
    private readonly IContestantService _contestantService;

    public CreateNewContestantModel(IContestantService contestantService)
    {
        _contestantService = contestantService;
    }

    // Thuộc tính bind dữ liệu
    [BindProperty] public string KoiName { get; set; }
    [BindProperty] public string KoiBreed { get; set; }
    [BindProperty] public decimal KoiSize { get; set; }
    [BindProperty] public string KoiColor { get; set; }
    [BindProperty] public decimal KoiGPA { get; set; }
    [BindProperty] public string Email { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Vui lòng điền đầy đủ thông tin.";
            return Page();
        }

        var koi = new KoiManagement
        {
            Name = KoiName,
            Breed = KoiBreed,
            Size = KoiSize,
            Color = KoiColor,
            DateOfEntry = DateOnly.FromDateTime(DateTime.Now),
            Origin = "User Input",
            HealthStatus = "Healthy",
            ContestCategory = null, // Hoặc cung cấp giá trị cụ thể nếu cần
            ContestStatus = "Pending",
            ContestDate = null,
            Notes = null,
            UserEmail = Email,
            Gpa = KoiGPA,
            IdUser = null,
            VoteCount = 0
        };

        var success = await _contestantService.RegisterKoiAsync(koi);
        if (success)
        {
            TempData["SuccessMessage"] = "Đăng ký thành công!";
            return RedirectToPage("./CreateNewForContestant");
        }
        else
        {
            TempData["ErrorMessage"] = "Có lỗi xảy ra khi lưu thông tin.";
            return Page();
        }
    }
}

using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class CheckInModel : PageModel
{
    private readonly IKoiCheckInService _koiCheckInService;
    private readonly IKoiManagementService _koiManagementService;

    public CheckInModel(IKoiCheckInService koiCheckInService, IKoiManagementService koiManagementService)
    {
        _koiCheckInService = koiCheckInService;
        _koiManagementService = koiManagementService;
    }

    [BindProperty]
    public int KoiID { get; set; }

    [BindProperty]
    public string HealthStatus { get; set; }

    [BindProperty]
    public string Notes { get; set; }

    public string ResultMessage { get; set; }

    // Danh sách cá Koi
    public List<KoiManagement> KoiList { get; set; }

    // Phương thức xử lý GET khi trang được tải
    public async Task OnGetAsync()
    {
        try
        {
            // Lấy tất cả cá Koi từ service
            KoiList = await _koiManagementService.GetAllKoiAsync();

            // Kiểm tra và đảm bảo KoiList không phải null, nếu có thì khởi tạo danh sách trống
            if (KoiList == null)
            {
                KoiList = new List<KoiManagement>();  // Gán danh sách trống nếu không có dữ liệu

            }
        }
        catch (Exception ex)
        {
            // Hiển thị thông báo lỗi trong trường hợp có lỗi khi tải danh sách cá Koi
            ResultMessage = "Có lỗi xảy ra khi tải danh sách cá Koi: " + ex.Message;
        }
    }

    // Phương thức xử lý POST khi người dùng submit form
    public async Task OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            // Thực hiện check-in cá Koi
            ResultMessage = await _koiCheckInService.CheckInKoiAsync(KoiID, HealthStatus, Notes);

            // Sau khi thực hiện check-in, chúng ta cần tải lại danh sách Koi
            await OnGetAsync();
        }
        else
        {
            ResultMessage = "Dữ liệu không hợp lệ.";
        }
    }
}

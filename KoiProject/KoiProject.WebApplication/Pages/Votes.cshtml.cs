using KoiProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Pages

{
    public class VotesModel : PageModel
    {
        private readonly IVoteService _voteService;

        public VotesModel(IVoteService voteService)
        {
            _voteService = voteService;
        }

        // Danh sách các cá Koi sẽ được hiển thị trên trang
        public IList<KoiManagement> KoiList { get; set; }

        // Phương thức này được gọi khi tải trang lần đầu
        public async Task OnGetAsync()
        {
            KoiList = await _voteService.GetAllKoiAsync();
        }

        // Phương thức này được gọi khi người dùng thực hiện hành động bình chọn
        public async Task<IActionResult> OnPostVoteAsync(int koiId)
        {
            string voterEmail = User.Identity.Name; // Lấy email người dùng hiện tại
            bool success = await _voteService.VoteForKoiAsync(koiId, voterEmail);

            if (success)
            {
                // Sau khi bình chọn thành công, quay lại trang để hiển thị cập nhật
                return RedirectToPage();
            }
            else
            {
                // Xử lý khi bình chọn không thành công (có thể do koiId không tồn tại)
                ModelState.AddModelError(string.Empty, "Bình chọn không thành công. Vui lòng thử lại.");
                return Page();
            }
        }
    }
}
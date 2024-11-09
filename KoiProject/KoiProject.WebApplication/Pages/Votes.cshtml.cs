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
        public async Task<IActionResult> OnPostVoteAsync(int id)
        {
            var result = await _voteService.IncreaseVoteAsync(id);
            if (!result)
            {
                return NotFound(); // Nếu không tìm thấy hoặc không thể bình chọn
            }

            return RedirectToPage(); // Reload trang sau khi bình chọn thành công

        }

    }

}


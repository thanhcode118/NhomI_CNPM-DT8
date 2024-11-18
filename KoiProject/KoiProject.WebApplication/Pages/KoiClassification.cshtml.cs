using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace KoiProject.WebApplication.Pages
{
    public class KoiClassificationModel : PageModel
    {
        private readonly IKoiService _koiService;

        public List<KoiClassification> KoiList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Classification { get; set; } // Phân loại được chọn (Small, Medium, Large)

        public KoiClassificationModel(IKoiService koiService)
        {
            _koiService = koiService;
        }

        public async Task OnGetAsync()
        {
            // Lấy danh sách cá Koi theo phân loại
            KoiList = await _koiService.GetClassifiedKoiAsync();

            if (!string.IsNullOrEmpty(Classification))
            {
                KoiList = KoiList.FindAll(k => k.SizeCategory == Classification);
            }
        }
    }
}


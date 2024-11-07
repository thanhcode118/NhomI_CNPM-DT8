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

        public IList<KoiManagement> KoiManagement { get; set; } = new List<KoiManagement>(); // Khởi tạo danh sách rỗng để tránh null

        public async Task OnGetAsync()
        {
            KoiManagement = (await _koiManagementService.GetAllKoisAsync()).ToList();
        }
    }


}

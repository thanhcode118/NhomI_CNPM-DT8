using Microsoft.EntityFrameworkCore;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using KoiProject.Service.Interfaces;
using KoiProject.Service;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Đăng ký Razor Pages và Blazor
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        // Đăng ký DbContext với SQL Server
        builder.Services.AddDbContext<KoiCompetitionContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Đăng ký các repository và service
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IKoiManagementRepository, KoiManagementRepository>();
        builder.Services.AddScoped<IKoiManagementService, KoiManagementService>();
        //builder.Services.AddScoped<IRankingService, RankingService>();
        //builder.Services.AddScoped<IRankingRepository, RankingRepository>();
        //builder.Services.AddScoped<IVoteService, VoteService>();
        //builder.Services.AddScoped<IVoteRepository, VoteRepository>();

        // Đăng ký Session
        builder.Services.AddSession();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts(); // Cấu hình HSTS cho môi trường production
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization(); // Middleware xác thực
        app.UseSession(); // Middleware Session

        // Định nghĩa route cho Blazor và Razor Pages
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        app.MapRazorPages();

        app.Run();
    }
}

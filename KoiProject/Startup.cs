using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    // Phương thức này được gọi để thêm dịch vụ vào container DI.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddScoped<LoginService>();
        services.AddScoped<IRankingRepository, RankingRepository>();
        services.AddScoped<IRankingService, RankingService>();
        services.AddControllersWithViews();
    }

    // Phương thức này được gọi để cấu hình pipeline của ứng dụng.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Hiển thị lỗi chi tiết khi ở chế độ phát triển
        }
        else
        {
            app.UseExceptionHandler("/Error"); // Chỉ định trang lỗi cho các lỗi không xử lý
            app.UseHsts(); // Bật HSTS
        }

        app.UseHttpsRedirection(); // Chuyển hướng tất cả yêu cầu HTTP sang HTTPS
        app.UseStaticFiles(); // Sử dụng các file tĩnh (CSS, JS, hình ảnh)

        app.UseRouting(); // Kích hoạt middleware định tuyến

        app.UseAuthorization(); // Kích hoạt middleware xác thực

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages(); // Định nghĩa các endpoint cho Razor Pages
        });
    }
}

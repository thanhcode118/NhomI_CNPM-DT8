using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using KoiProject.Service.Interfaces;
using KoiProject.Service;
using KoiProject.Repositories.Entities;




var builder = WebApplication.CreateBuilder(args);

// Đăng ký Razor Pages và Blazor
builder.Services.AddRazorPages();
builder.Services.AddDbContext<KoiCompetitionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddRazorPages();

builder.Services.AddSession(); 

builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Cấu hình HSTS cho môi trường production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Bắt buộc để xử lý định tuyến cho Razor Pages và Blazor

app.UseAuthorization(); // Sử dụng middleware xác thực (nếu có)

// Định nghĩa route cho Blazor và Razor Pages
app.MapBlazorHub(); // Map endpoint cho Blazor
app.MapFallbackToPage("/_Host"); // Dự phòng cho Blazor nếu không tìm thấy route

app.MapRazorPages(); // Map Razor Pages
app.UseSession();

app.Run();
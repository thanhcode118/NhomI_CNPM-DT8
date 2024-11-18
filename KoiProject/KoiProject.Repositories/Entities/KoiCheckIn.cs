using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KoiCheckIn
{
    public int CheckInID { get; set; }  // Khóa chính (nếu bạn muốn tạo khóa chính tự động)
    public int KoiID { get; set; }         // ID của cá Koi
    public string HealthStatus { get; set; } // Tình trạng sức khỏe của cá Koi (Healthy, Moderate, Excellent)
    public string Notes { get; set; }        // Ghi chú liên quan đến check-in
    public DateTime CheckInTime { get; set; } // Ngày check-in

    // Điều này giúp Entity Framework biết đây là bảng mà bạn muốn ánh xạ trong cơ sở dữ liệu
}
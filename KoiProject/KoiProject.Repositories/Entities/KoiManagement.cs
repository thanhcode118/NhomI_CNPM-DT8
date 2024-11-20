using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class KoiManagement
{
    public int KoiId { get; set; } // ID của cá Koi

    public string Name { get; set; } = null!; // Tên cá Koi

    public string Breed { get; set; } = null!; // Giống cá

    public decimal Size { get; set; } // Kích thước (cm)

    public string? Color { get; set; } // Màu sắc

    public DateOnly? DateOfEntry { get; set; } // Ngày nhập vào

    public string? Origin { get; set; } // Nguồn gốc

    public decimal? Price { get; set; } // Giá bán (nếu có)

    public string? HealthStatus { get; set; } // Tình trạng sức khỏe (Healthy, Moderate, etc.)

    public string UserEmail { get; set; } // Email người dùng liên quan

    public decimal Gpa { get; set; } // GPA của người dùng liên quan

    public int? IdUser { get; set; } // ID người dùng liên quan

    public int VoteCount { get; set; } // Số lượng bình chọn

    public virtual User? IdUserNavigation { get; set; } // Navigation đến User dựa trên IdUser

    public virtual User UserEmailNavigation { get; set; } = null!; // Navigation đến User dựa trên Email

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>(); // Navigation đến bảng Vote

    public string? ContestCategory { get; set; } // Hạng mục thi đấu

    public string ContestStatus { get; set; } = "Pending"; // Trạng thái thi đấu: Pending, Registered, Approved, Rejected

    public DateTime? ContestDate { get; set; } // Ngày thi đấu (nếu có)

    public string? Notes { get; set; } // Ghi chú bổ sung (tùy chọn)
}

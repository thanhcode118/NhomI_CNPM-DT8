using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoiProject.Repositories.Entities
{
    public class Contestant
    {
        [Key] // Đặt làm khóa chính
        public int Id { get; set; } // ID của thí sinh

        [Required(ErrorMessage = "Tên thí sinh không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên thí sinh không được vượt quá 100 ký tự.")]
        public string Name { get; set; } // Tên thí sinh

        [Required(ErrorMessage = "Quốc gia/Nguồn gốc không được để trống.")]
        [StringLength(100, ErrorMessage = "Nguồn gốc không được vượt quá 100 ký tự.")]
        public string Origin { get; set; } // Quốc gia/Nguồn gốc

        [Required(ErrorMessage = "Hạng mục thi đấu không được để trống.")]
        [StringLength(50, ErrorMessage = "Hạng mục không được vượt quá 50 ký tự.")]
        public string Category { get; set; } // Hạng mục thi đấu

        [Required(ErrorMessage = "Kích thước không được để trống.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Kích thước phải là số hợp lệ.")]
        public string Size { get; set; } // Kích thước cá tham gia (nếu cần)

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; } // Email của thí sinh

        [Required(ErrorMessage = "Cần chọn một cá Koi.")]
        [ForeignKey("Koi")]
        public int KoiId { get; set; } // ID của cá Koi được tham chiếu

        [Required(ErrorMessage = "Cần liên kết với một người dùng.")]
        [ForeignKey("User")]
        public int UserId { get; set; } // ID người dùng liên kết với thí sinh

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.Now; // Ngày đăng ký

        [Required]
        [StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự.")]
        public string Status { get; set; } = "Pending"; // Trạng thái của thí sinh

        [Range(0, 100, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 100.")]
        public decimal? Score { get; set; } // Điểm thi đấu (nếu có)

        [StringLength(50, ErrorMessage = "Kết quả không được vượt quá 50 ký tự.")]
        public string FinalResult { get; set; } // Kết quả cuối cùng

        // Navigation property đến bảng KoiManagement
        public KoiManagement Koi { get; set; }

        // Navigation property đến bảng User
        public User User { get; set; }
    }
}

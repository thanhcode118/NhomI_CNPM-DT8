using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoiProject.Repositories.Entities // Đảm bảo đúng namespace
{
    [Table("KoiManagement")] // Đảm bảo tên bảng đúng với tên trong CSDL
    public class KoiManagement
    {
        [Key]
        public int KoiId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public decimal Size { get; set; }
        public string Color { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string Origin { get; set; }
        public decimal Price { get; set; }
        public string HealthStatus { get; set; }
        public string UserEmail { get; set; }
        public int VoteCount { get; set; }
        public decimal Gpa { get; set; }

        [ForeignKey("UserEmail")]
        public virtual User UserEmailNavigation { get; set; }
    }
}

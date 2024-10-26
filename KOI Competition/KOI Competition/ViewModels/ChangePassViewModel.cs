using System.ComponentModel.DataAnnotations;

namespace KOI_Competition.ViewModels
{
    public class ChangePassViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [Compare("ComfirmNewPassword", ErrorMessage = "Password does not match.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Comfirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Comfirm new password")]
        public string ComfirmNewPassword { get; set; }
    }
}

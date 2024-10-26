using System.ComponentModel.DataAnnotations;

namespace KOI_Competition.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Compare("ComfirmPassword", ErrorMessage = "Password does not match.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Comfirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Comfirm password")]
        public string ComfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BuildService.Mvc.Api.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string? UserName { get; set; }
        [Required]
        [UIHint("password")]
        [Display (Name = "Password")]
        public string? Password { get; set; }
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; } = false;
    }
}

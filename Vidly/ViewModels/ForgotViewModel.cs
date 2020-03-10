using System.ComponentModel.DataAnnotations;

namespace UDemyVidly.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

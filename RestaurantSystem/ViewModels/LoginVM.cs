using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.ViewModels
{
    public class LoginVM
    {
        [Display(Name="Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string UserMail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

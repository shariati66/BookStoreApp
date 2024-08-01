using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class DataAnnotationTestViewModel
    {
        [Required(ErrorMessage ="this is required.")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^09\d{9}")]
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}

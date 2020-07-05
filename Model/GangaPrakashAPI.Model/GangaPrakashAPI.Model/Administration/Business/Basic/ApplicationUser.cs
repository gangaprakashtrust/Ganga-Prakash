using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace GangaPrakashAPI.Model
{
    public class ApplicationUser : BaseModel
    {
        public Guid UserId { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        public String ShortName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo { get; set; }

        public Boolean IsDoctor { get; set; }

        public String ImagePath { get; set; }

        //Extra Fields

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class Doctor : BaseModel
    {
        [Required]
        public String FirstName { get; set; }

        [Required]
        public String MiddleName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String DOB { get; set; }

        [Required]
        public String MedicalRegistrationNo { get; set; }

        [Required]
        public Guid GenderId { get; set; }

        public Guid AddressId { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo { get; set; }

        public String DoctorImageBase64String { get; set; }

        public String DoctorSignatureBase64String { get; set; }

        public Guid ApplicationUserId { get; set; }



    }
}

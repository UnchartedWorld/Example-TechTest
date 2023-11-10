using MotivWebApp.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.DTOs
{
    public class ApplicationRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = Constants.INVALID_GENERAL_INPUT_MESSAGE)]
        [RegularExpression(@"^([\p{L}\p{M}\p{Z}-,])+$", ErrorMessage = Constants.INVALID_TITLE_MESSAGE)]
        public string Title { get; set; }
        [Required]
        // Chose this length based on https://en.wikipedia.org/wiki/Hubert_Blaine_Wolfeschlegelsteinhausenbergerdorff_Sr.
        [StringLength(960, MinimumLength = 3, ErrorMessage = Constants.INVALID_GENERAL_INPUT_MESSAGE)]
        [RegularExpression(@"^([\p{L}\p{M}\p{Z}-,])+$", ErrorMessage = Constants.INVALID_NAME_MESSAGE)]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = Constants.INVALID_EMAIL_MESSAGE)]
        [StringLength(200, ErrorMessage = Constants.INVALID_EMAIL_MESSAGE)]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        [Phone]
        public string? PhoneNum { get; set; }
        [Required]
        // Got the idea for a Unicode-compliant regex from https://dev.to/tillsanders/let-s-stop-using-a-za-z-4a0m#comment-1c902.
        // This will allow names like John Äpfel.
        [RegularExpression(@"^([\p{L}\p{M}\p{N}\p{Z}-,])+$", ErrorMessage = Constants.INVALID_ADDRESS_MESSAGE)]
        public string Address { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        [DoB(MinimumAge = Constants.MINIMUM_AGE, MaximumAge = Constants.MAXIMUM_AGE)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DisplayName("Deposit Amount")]
        [Range(1, int.MaxValue, ErrorMessage = Constants.INVALID_GENERAL_INPUT_MESSAGE)]
        public int DepositAmount { get; set; }
        [Required]
        [DisplayName("Car Price")]
        [Range(1, int.MaxValue, ErrorMessage = Constants.INVALID_GENERAL_INPUT_MESSAGE)]
        public int CarPrice { get; set; }
        [Required]
        [DisplayName("Number of Repay Years")]
        public int NumOfRepayYears { get; set; }
        [Required]
        [DisplayName("Driving License")]
        public int DrivingLicenseID { get; set; }
        [Required]
        [DisplayName("Marital Status")]
        public int MaritalStatusID { get; set; }
    }
}

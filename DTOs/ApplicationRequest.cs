using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.DTOs
{
    public class ApplicationRequest
    {
        [Required]
        [StringLength(20, ErrorMessage = "Title is too long")]
        public string Title { get; set; }
        [Required]
        // Chose this length based on https://en.wikipedia.org/wiki/Hubert_Blaine_Wolfeschlegelsteinhausenbergerdorff_Sr.
        [StringLength(960, ErrorMessage = "Name is too long for this system")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email appears to be invalid. Please provide a different one")]
        [StringLength(200, ErrorMessage = "Email address is too long for this system")]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        [Phone]
        public int? PhoneNum { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DisplayName("Deposit Amount")]
        [Range(1, int.MaxValue, ErrorMessage = "Deposit amount is invalid for this system")]
        public int DepositAmount { get; set; }
        [Required]
        [DisplayName("Car Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Deposit amount is invalid for this system")]
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

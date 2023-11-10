using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivWebApp.Models
{
    public class TableApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }
        public string ApplicantTitle { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public string? ApplicantPhoneNum { get; set; }
        public string ApplicantAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ApplicantDepositAmount { get; set; }
        public int ApplicantCarPrice { get; set; }
        public int NumOfRepayYears { get; set; }

    }
}

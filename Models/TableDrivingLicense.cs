using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivWebApp.Models
{
    public class TableDrivingLicense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrivingLicenseID { get; set; }
        public string DrivingLicenseName { get; set; }
    }
}

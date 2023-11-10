using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivWebApp.Models
{
    public class TableAppInputRelations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppInputRelationsID { get; set; }
        [ForeignKey("TableApplication")]
        public int ApplicationID { get; set; }
        [ForeignKey("TableDrivingLicense")]
        public int DrivingLicenseID { get; set; }
        [ForeignKey("TableMaritalStatus")]
        public int MaritalStatusID { get; set; }
        public TableApplication TableApplication { get; set; }
        public TableDrivingLicense TableDrivingLicense { get; set; }
        public TableMaritalStatus TableMaritalStatus { get; set; }

    }
}

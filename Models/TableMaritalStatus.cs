using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivWebApp.Models
{
    public class TableMaritalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaritalStatusID { get; set; }
        public string MaritalStatusName { get; set; }
    }
}

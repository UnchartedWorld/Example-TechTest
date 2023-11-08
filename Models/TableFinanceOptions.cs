using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivWebApp.Models
{
    public class TableFinanceOptions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FinanceOptionID { get; set; }
        public string FinanceLoanName { get; set; }
        public decimal FinanceLoanRate { get; set; }
        public int MinLoanAmount { get; set; }
        public int MaxLoanAmount { get; set; }
    }
}

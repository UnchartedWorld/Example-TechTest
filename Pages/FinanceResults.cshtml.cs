using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Data;
using MotivWebApp.DTOs;
using MotivWebApp.Models;
using MotivWebApp.Services;

namespace MotivWebApp.Pages
{
    public class FinanceResultsModel : PageModel
    {
        private FinanceService _financeService;

        public List<FinanceOptionsResponse> FinanceOptionsResponses { get; set; }

        public FinanceResultsModel(FinanceService financeService)
        {
            _financeService = financeService;

            // Initialises empty lists
            FinanceOptionsResponses = new List<FinanceOptionsResponse>();

        }

        public async void OnGetAsync()
        {
            int? applicantID = (int?)TempData["applicantID"];

            List<FinanceOptionsResponse> validFinances = await _financeService.GetApplicableFinance(applicantID);
            List<FinanceOptionsResponse> financeOptionsResponse = validFinances;

            FinanceOptionsResponses.AddRange(financeOptionsResponse);

        }
    }
}

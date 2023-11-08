using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Data;
using MotivWebApp.DTOs;
using MotivWebApp.Models;

namespace MotivWebApp.Pages
{
    public class InsuranceApplicationModel : PageModel
    {
        private readonly DBContext _dBContext;

        [BindProperty]
        public ApplicationRequest ApplicationRequest { get; set; }
        public List<TableDrivingLicense> DrivingLicenses { get; set; }
        public List<TableMaritalStatus> MaritalStatuses { get; set; }

        public InsuranceApplicationModel(DBContext dBContext)
        {
            _dBContext = dBContext;

            // Initialises the lists
            DrivingLicenses = new List<TableDrivingLicense>();
            MaritalStatuses = new List<TableMaritalStatus>();
        }
        public void OnGet()
        {
            List<TableDrivingLicense> retrievedDrivingLicenses = _dBContext.TableDrivingLicense.ToList();
            List<TableMaritalStatus> retrievedMartialStatuses = _dBContext.TableMaritalStatus.ToList();

            if (retrievedDrivingLicenses.Count > 0 && retrievedMartialStatuses.Count > 0)
            {
                DrivingLicenses.AddRange(retrievedDrivingLicenses);
                MaritalStatuses.AddRange(retrievedMartialStatuses);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ApplicationRequest.CarPrice < ApplicationRequest.DepositAmount)
            {
                ModelState.AddModelError("ApplicationRequest.CarPrice", "Car price cannot be less than the deposit amount");
            }
            if (ApplicationRequest.DepositAmount > ApplicationRequest.CarPrice)
            {
                ModelState.AddModelError("ApplicationRequest.DepositAmount", "Deposit amount cannot be greater than the car price");
            }
            if (ApplicationRequest.MaritalStatusID.ToString() == "")
            {
                ModelState.AddModelError("ApplicationRequest.MaritalStatus", "Please select a marital status option");
            }

            if (!ModelState.IsValid)
            {
                // This should do something if an error has occured with POSTing it.
                return Page();
            }
            else
            {
                TableApplication submittedApplication = new()
                {
                    ApplicantTitle = ApplicationRequest.Title,
                    ApplicantName = ApplicationRequest.Name,
                    ApplicantAddress = ApplicationRequest.Address,
                    ApplicantEmail = ApplicationRequest.Email,
                    ApplicantPhoneNum = ApplicationRequest.PhoneNum,
                    ApplicantDepositAmount = ApplicationRequest.DepositAmount,
                    ApplicantCarPrice = ApplicationRequest.CarPrice,
                    DateOfBirth = ApplicationRequest.DateOfBirth,
                    NumOfRepayYears = ApplicationRequest.NumOfRepayYears
                };

                _dBContext.TableApplication.Add(submittedApplication);
                await _dBContext.SaveChangesAsync();

                // We want the ID of the last application since they'll have the correct application ID to go with their choices.
                TableAppInputRelations submittedRelations = new()
                {
                    ApplicationID = submittedApplication.ApplicationID,
                    MaritalStatusID = ApplicationRequest.MaritalStatusID,
                    DrivingLicenseID = ApplicationRequest.DrivingLicenseID
                };

                _dBContext.TableAppInputRelations.Add(submittedRelations);

                await _dBContext.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
        }
    }
}

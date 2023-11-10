using Microsoft.EntityFrameworkCore;
using MotivWebApp.Data;
using MotivWebApp.DTOs;
using MotivWebApp.Models;

namespace MotivWebApp.Services
{
    public class FinanceService
    {
        private readonly DBContext _dBContext;

        public FinanceService(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// Takes an integer parameter, performs a few database searches and returns a list.
        /// More specifically, after retrieving the desired integer and confirming it's not null, it first ensures that the application
        /// didn't return null, then filters the FinanceOptions table to only show those meeting desired parameters i.e. more than minimum
        /// loan amount & lower than maximum loan amount.
        /// </summary>
        /// <param name="appID">Represents the application ID, ideally the one from the most recent application.</param>
        /// <returns>Either a list containing finance options, or an empty list.</returns>
        public async Task<List<FinanceOptionsResponse>> GetApplicableFinance(int? appID)
        {
            if (appID != null)
            {
                TableDrivingLicense noDrivingLicense = await _dBContext.TableDrivingLicense.FirstOrDefaultAsync(x => x.DrivingLicenseName == "None");

                TableApplication? validApplication = await (from apprelations in _dBContext.TableAppInputRelations
                                              join application in _dBContext.TableApplication on apprelations.ApplicationID equals application.ApplicationID
                                              join driving in _dBContext.TableDrivingLicense on apprelations.DrivingLicenseID equals driving.DrivingLicenseID
                                              where application.ApplicationID == appID && apprelations.DrivingLicenseID != noDrivingLicense.DrivingLicenseID
                                              select application).FirstOrDefaultAsync();

                if (validApplication != null)
                {
                    int loanAmount = (validApplication.ApplicantCarPrice - validApplication.ApplicantDepositAmount);

                    List<FinanceOptionsResponse> validFinanceOptions = await _dBContext.TableFinanceOptions
                        .Where(x => loanAmount > x.MinLoanAmount && loanAmount < x.MaxLoanAmount).Select(x => new FinanceOptionsResponse
                        {
                            FinanceOptionsID = x.FinanceOptionID,
                            FinanceLoanRate = x.FinanceLoanRate,
                            FinanceOptionsName = x.FinanceLoanName
                        }).ToListAsync();

                    return validFinanceOptions;
                }
            }

            // If nothing is found, return an empty list.
            return new List<FinanceOptionsResponse>();
        }
    }
}

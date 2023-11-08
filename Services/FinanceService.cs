using Microsoft.EntityFrameworkCore;
using MotivWebApp.Data;
using MotivWebApp.DTOs;

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
        /// 
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public async Task<List<FinanceOptionsResponse>> GetApplicableFinance(int? appID)
        {
            if (appID != null)
            {
                var validApplication = await (from apprelations in _dBContext.TableAppInputRelations
                                              join application in _dBContext.TableApplication on apprelations.ApplicationID equals application.ApplicationID
                                              join driving in _dBContext.TableDrivingLicense on apprelations.DrivingLicenseID equals driving.DrivingLicenseID
                                              where application.ApplicationID == appID && apprelations.DrivingLicenseID != 5
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

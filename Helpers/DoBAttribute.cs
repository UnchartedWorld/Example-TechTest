using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Helpers
{
    // This is a slightly modified version of https://stackoverflow.com/a/3310313
    public class DoBAttribute : ValidationAttribute
    {
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }

        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            DateTime val = (DateTime)value;
            DateTime today = DateTime.Now;
            bool validAge = false;

            // This will tell the system how old the individual is.
            int inputAge = today.Year - val.Year;

            // This accounts for leap years.
            if (val.Date > today.AddYears(-inputAge))
                --inputAge;

            if (inputAge < MinimumAge)
            {
                ErrorMessage = $"You cannot be younger than {MinimumAge} to use this system";
                validAge = false;
            }
            else if (inputAge > MaximumAge)
            {
                ErrorMessage = $"You cannot be older than {MaximumAge} to use this system";
                validAge = false;
            }

            if (inputAge > MinimumAge && inputAge <= MaximumAge && MinimumAge <= MaximumAge)
            {
                validAge = true;
            }

            return validAge;
        }
    }
}

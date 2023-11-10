
namespace MotivWebApp.Helpers
{
    public static class Constants
    {
        public const int MINIMUM_AGE = 18;
        public const int MAXIMUM_AGE = 120;

        public const string INVALID_TITLE_MESSAGE = "Title contains characters not accepted by this system";
        public const string INVALID_NAME_MESSAGE = "Name contains characters not accepted by this system";
        public const string INVALID_ADDRESS_MESSAGE = "Address contains characters not accepted by this system";
        public const string INVALID_DOB_MESSAGE = "Invalid date of birth provided for this system";
        public const string INVALID_EMAIL_MESSAGE = "Email appears to be invalid for this system";
        public const string INVALID_GENERAL_INPUT_MESSAGE = "Input is of an invalid length for this system";
        public const string INVALID_DEPOSIT_MESSAGE = "Deposit amount cannot be greater than the car price";
        public const string INVALID_PRICE_MESSAGE = "Car price cannot be less than the deposit amount";
        public const string EMPTY_MARITAL_MESSAGE = "Please select your marital status";
        public const string EMPTY_DRIVING_MESSAGE = "Please select your driving license";
        public const string EMPTY_REPAY_YEARS_MESSAGE = "Please select the number of repayment years";
    }
}

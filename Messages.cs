using PX.Common;
using PX.Data;

namespace RentalServiceSetA
{
    [PXLocalizable]
    public static class Messages
    {
        public const string DailyRateExceedsWeekly =
            "Daily Rate cannot exceed Weekly Rate divided by 6.";

        public const string DailyRateExceedsMonthly =
            "Daily Rate cannot exceed Monthly Rate divided by 22.";

        public const string RentalCreditLimitRequired =
            "Rental Credit Limit must be greater than zero for rental customers.";

        public const string DailyRateMustBePositive =
    "Daily Rate must be greater than zero.";

        public const string CategoryChanged =
    "Equipment category has been changed.";

        public const string AtLeastOneRateRequired =
    "At least one rental rate (Daily, Weekly, or Monthly) must be greater than zero.";


    }
}

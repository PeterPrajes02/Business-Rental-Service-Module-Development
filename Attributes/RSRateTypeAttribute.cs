using PX.Data;

namespace RentalServiceSetA
{
    public class RSRateTypeAttribute : PXStringListAttribute
    {
        public const string Daily = "D";
        public const string Weekly = "W";
        public const string Monthly = "M";

        public RSRateTypeAttribute()
            : base(
                new[]
                {
                    Daily,
                    Weekly,
                    Monthly
                },
                new[]
                {
                    "Daily",
                    "Weekly",
                    "Monthly"
                })
        {
        }
    }
}

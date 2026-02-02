using PX.Data;

namespace RentalServiceSetA
{
    public class RSEquipmentStatusAttribute : PXStringListAttribute
    {
        public const string Available = "A";
        public const string Rented = "R";
        public const string Maintenance = "M";
        public const string Retired = "X";

        public RSEquipmentStatusAttribute()
            : base(
                new[]
                {
                    Available,
                    Rented,
                    Maintenance,
                    Retired
                },
                new[]
                {
                    "Available",
                    "Rented",
                    "Maintenance",
                    "Retired"
                })
        {
        }
    }
}

using PX.Common;
using PX.Data;
using System;

namespace RentalServiceSetA
{
    [PXCacheName("Rental Equipment")]
    public class RSEquipment : PXBqlTable, IBqlTable
    {
        #region EquipmentID
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }

        [PXDBIdentity]
        [PXUIField(DisplayName = "Equipment ID")]
        public virtual int? EquipmentID { get; set; }
        #endregion

        #region EquipmentCD
        public abstract class equipmentCD : PX.Data.BQL.BqlString.Field<equipmentCD> { }

        [PXDBString(30, IsUnicode = true, IsKey = true)]
        [PXDefault]
        [PXUIField(DisplayName = "Equipment Code")]
        public virtual string EquipmentCD { get; set; }
        #endregion

        #region Description
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }

        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        #endregion

        #region CategoryID
        public abstract class categoryID : PX.Data.BQL.BqlInt.Field<categoryID> { }

        [PXDBInt]
        [PXDefault]
        [PXUIField(DisplayName = "Category")]
        [PXSelector(
            typeof(Search<RSEquipmentCategory.categoryID>),
            SubstituteKey = typeof(RSEquipmentCategory.categoryCD),
            DescriptionField = typeof(RSEquipmentCategory.description)
        )]
        public virtual int? CategoryID { get; set; }
        #endregion

        #region DailyRate
        public abstract class dailyRate : PX.Data.BQL.BqlDecimal.Field<dailyRate> { }

        [PXDBDecimal]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Daily Rate")]
        public virtual decimal? DailyRate { get; set; }
        #endregion

        #region WeeklyRate
        public abstract class weeklyRate : PX.Data.BQL.BqlDecimal.Field<weeklyRate> { }

        [PXDBDecimal]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Weekly Rate")]
        public virtual decimal? WeeklyRate { get; set; }
        #endregion

        #region MonthlyRate
        public abstract class monthlyRate : PX.Data.BQL.BqlDecimal.Field<monthlyRate> { }

        [PXDBDecimal]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Monthly Rate")]
        public virtual decimal? MonthlyRate { get; set; }
        #endregion

        #region Status
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }

        [PXDBString(1)]
        [RSEquipmentStatus]
        [PXUIField(DisplayName = "Status")]
        public string Status { get; set; }

        #endregion

        #region PurchaseDate
        public abstract class purchaseDate : PX.Data.BQL.BqlDateTime.Field<purchaseDate> { }

        [PXDBDate]
        [PXUIField(DisplayName = "Purchase Date")]
        public virtual DateTime? PurchaseDate { get; set; }
        #endregion

        #region PurchaseCost
        public abstract class purchaseCost : PX.Data.BQL.BqlDecimal.Field<purchaseCost> { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Purchase Cost")]
        public virtual decimal? PurchaseCost { get; set; }
        #endregion

        #region DaysOwned
        public abstract class daysOwned : PX.Data.BQL.BqlInt.Field<daysOwned> { }

        [PXInt]
        [PXUIField(DisplayName = "Days Owned", Enabled = false)]
        public int? DaysOwned
        {
            get
            {
                if (PurchaseDate == null)
                    return null;

                return (PXTimeZoneInfo.Now.Date - PurchaseDate.Value.Date).Days;
            }
        }
        #endregion



    }
}

using PX.Data;
using System;
using static PX.Objects.CR.CRCaseCommitments.FK;

namespace RentalServiceSetA
{
    public class RSEquipmentMaint : PXGraph<RSEquipmentMaint>
    {
        public PXSelect<RSEquipment> Equipment;
        public PXSelect<RSEquipmentCategory> Categories;

        #region Rate Calculations

        protected decimal? CalculateWeeklyRate(decimal? dailyRate)
        {
            return dailyRate == null ? null : dailyRate * 6;
        }

        protected decimal? CalculateMonthlyRate(decimal? dailyRate)
        {
            return dailyRate == null ? null : dailyRate * 22;
        }

        #endregion

        #region Actions

        public PXAction<RSEquipment> CalculateRates;

        [PXButton]
        [PXUIField(DisplayName = "Calculate Rates")]
        protected void CalculateRatesAction()
        {
            var row = Equipment.Current;
            if (row == null)
                return;

            row.WeeklyRate = CalculateWeeklyRate(row.DailyRate);
            row.MonthlyRate = CalculateMonthlyRate(row.DailyRate);

            Equipment.Update(row);
        }

        #endregion

        #region Field Events

        protected void _(Events.FieldVerifying<RSEquipment.dailyRate> e)
        {
            var row = (RSEquipment)e.Row;
            if (row == null)
                return;

            decimal? newDailyRate = (decimal?)e.NewValue;
            if (!newDailyRate.HasValue)
                return;

            if (newDailyRate <= 0)
            {
                throw new PXSetPropertyException<RSEquipment.dailyRate>(
                    Messages.DailyRateMustBePositive
                );
            }

            if (row.WeeklyRate.HasValue && row.WeeklyRate / 6 < newDailyRate)
            {
                throw new PXSetPropertyException<RSEquipment.dailyRate>(
                    Messages.DailyRateExceedsWeekly
                );
            }

            if (row.MonthlyRate.HasValue && row.MonthlyRate / 22 < newDailyRate)
            {
                throw new PXSetPropertyException<RSEquipment.dailyRate>(
                    Messages.DailyRateExceedsMonthly
                );
            }
        }

        protected void _(Events.FieldDefaulting<RSEquipment.status> e)
        {
            e.NewValue = "A";
        }

        protected void _(Events.FieldUpdated<RSEquipment.categoryID> e)
        {
            if (e.Row != null)
            {
                PXUIFieldAttribute.SetWarning<RSEquipment.categoryID>(
                    e.Cache,
                    e.Row,
                    Messages.CategoryChanged
                );
            }
        }

        #endregion

        #region Row Events

        protected void _(Events.RowSelected<RSEquipment> e)
        {
            var row = e.Row;
            if (row == null)
                return;

            bool isRetired = row.Status == "X";

            PXUIFieldAttribute.SetEnabled<RSEquipment.dailyRate>(e.Cache, row, !isRetired);
            PXUIFieldAttribute.SetEnabled<RSEquipment.weeklyRate>(e.Cache, row, !isRetired);
            PXUIFieldAttribute.SetEnabled<RSEquipment.monthlyRate>(e.Cache, row, !isRetired);
        }

        protected void _(Events.RowInserting<RSEquipment> e)
        {
            var row = e.Row;
            if (row == null)
                return;

            if (row.PurchaseDate == null)
            {
                row.PurchaseDate = Accessinfo.BusinessDate;
            }
        }

        protected void _(Events.RowPersisting<RSEquipment> e)
        {
            var row = e.Row;
            if (row == null)
                return;

            bool hasAnyRate =
                (row.DailyRate.HasValue && row.DailyRate > 0) ||
                (row.WeeklyRate.HasValue && row.WeeklyRate > 0) ||
                (row.MonthlyRate.HasValue && row.MonthlyRate > 0);

            if (!hasAnyRate)
            {
                throw new PXRowPersistingException(
                    typeof(RSEquipment.dailyRate).Name,
                    row.DailyRate,
                    Messages.AtLeastOneRateRequired
                );
            }
        }



        #endregion

    }
}

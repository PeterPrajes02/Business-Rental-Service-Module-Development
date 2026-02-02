using PX.Data;
using PX.Objects.AR;
using System;

namespace RentalServiceSetA
{
    public sealed class CustomerMaintExt : PXGraphExtension<CustomerMaint>
    {
        public static bool IsActive() => true;

        public PXSelect<
    RSRentalContract,
    Where<RSRentalContract.customerID, Equal<Current<Customer.bAccountID>>>
> RentalContracts;

        #region Row Events

        protected void _(Events.RowPersisting<Customer> e)
        {
            var row = e.Row;
            if (row == null)
                return;

            var ext = row.GetExtension<CustomerExt>();
            if (ext == null)
                return;

            if (ext.UsrIsRentalCustomer == true &&
                (!ext.UsrRentalCreditLimit.HasValue || ext.UsrRentalCreditLimit <= 0))
            {
                throw new PXRowPersistingException(
                    typeof(CustomerExt.usrRentalCreditLimit).Name,
                    ext.UsrRentalCreditLimit,
                    Messages.RentalCreditLimitRequired
                );
            }
        }

        #endregion

        #region Actions

        public PXAction<Customer> ViewRentalHistory;

        [PXButton]
        [PXUIField(DisplayName = "View Rental History")]
        protected void ViewRentalHistoryAction()
        {
            // Stub action – intentionally left blank for exam purposes
        }

        #endregion





    }
}

using PX.Data;
using PX.Objects.AR;
using System;

namespace RentalServiceSetA
{
    public sealed class CustomerExt : PXCacheExtension<Customer>
    {
        public static bool IsActive() => true;

        #region UsrIsRentalCustomer
        public abstract class usrIsRentalCustomer : PX.Data.BQL.BqlBool.Field<usrIsRentalCustomer> { }

        [PXDBBool]
        [PXUIField(DisplayName = "Rental Customer")]
        public bool? UsrIsRentalCustomer { get; set; }
        #endregion

        #region UsrRentalCreditLimit
        public abstract class usrRentalCreditLimit : PX.Data.BQL.BqlDecimal.Field<usrRentalCreditLimit> { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Rental Credit Limit")]
        public decimal? UsrRentalCreditLimit { get; set; }
        #endregion

        #region UsrRentalDiscount
        public abstract class usrRentalDiscount : PX.Data.BQL.BqlDecimal.Field<usrRentalDiscount> { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Rental Discount (%)")]
        public decimal? UsrRentalDiscount { get; set; }
        #endregion

        #region UsrPreferredRateType
        public abstract class usrPreferredRateType : PX.Data.BQL.BqlString.Field<usrPreferredRateType> { }

        [PXDBString(1)]
        [RSRateType]
        [PXUIField(DisplayName = "Preferred Rate Type")]
        public string UsrPreferredRateType { get; set; }

        #endregion
    }

}

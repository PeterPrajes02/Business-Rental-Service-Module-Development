using PX.Data;
using System;

namespace RentalServiceSetA
{
    [PXCacheName("Rental Contract")]
    public class RSRentalContract : PXBqlTable, IBqlTable
    {
        #region ContractID
        public abstract class contractID : PX.Data.BQL.BqlInt.Field<contractID> { }

        [PXDBIdentity]
        public int? ContractID { get; set; }
        #endregion

        #region CustomerID
        public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }

        [PXDBInt]
        [PXUIField(DisplayName = "Customer")]
        public int? CustomerID { get; set; }
        #endregion
    }
}

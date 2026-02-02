using System;
using PX.Data;

namespace RentalServiceSetA
{
    [PXCacheName("Equipment Category")]
    public class RSEquipmentCategory : PXBqlTable, IBqlTable
    {
        #region CategoryID
        public abstract class categoryID : PX.Data.BQL.BqlInt.Field<categoryID> { }

        [PXDBIdentity]
        [PXUIField(DisplayName = "Category ID")]
        public virtual int? CategoryID { get; set; }
        #endregion

        #region CategoryCD
        public abstract class categoryCD : PX.Data.BQL.BqlString.Field<categoryCD> { }

        [PXDBString(15, IsUnicode = true, IsKey = true)]
        [PXDefault]
        [PXUIField(DisplayName = "Category Code")]
        public virtual string CategoryCD { get; set; }
        #endregion

        #region Description
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }

        [PXDBString(100, IsUnicode = true)]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        #endregion

        #region IsActive
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }

        [PXDBBool]
        [PXDefault(true)]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? IsActive { get; set; }
        #endregion

        #region NoteID
        public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }

        [PXNote]
        public virtual Guid? NoteID { get; set; }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID { get; set; }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime]
        public virtual DateTime? CreatedDateTime { get; set; }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID { get; set; }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        #endregion

        #region Tstamp
        [PXDBTimestamp]
        public virtual byte[] Tstamp { get; set; }
        #endregion

    }
}

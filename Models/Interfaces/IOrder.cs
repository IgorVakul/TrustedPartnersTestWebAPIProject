using System;

namespace Models.Interfaces
{
    internal interface IOrder
    {
        #region Properties       

        int ORD_NUM { get; set; }
        decimal ORD_AMOUNT { get; set; }
        decimal ADVANCE_AMOUNT { get; set; }
        string CUST_CODE { get; set; }
        string AGENT_CODE { get; set; }
        string ORD_DESCRIPTION { get; set; }
        public DateTime ORD_DATE { get; set; }

        #endregion Properties

        #region Methods

       

        #endregion Methods
    }
}

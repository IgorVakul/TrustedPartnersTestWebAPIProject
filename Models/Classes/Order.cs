using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Order : IOrder
    {
        #region Properties

        [Key]
        [Column(TypeName = "int")]
        public int ORD_NUM { get; set; }

        [Column(TypeName = "float")]
        public decimal ORD_AMOUNT { get; set; }

        [Column(TypeName = "float")]
        public decimal ADVANCE_AMOUNT { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ORD_DATE { get; set; }

        [Column(TypeName = "varchar(6)")]
        public string CUST_CODE { get; set; }

        [Column(TypeName = "char(6)")]
        public string AGENT_CODE { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string ORD_DESCRIPTION { get; set; }

        #endregion Properties

        #region Constructors



        #endregion Constructors

        #region Methods

        /// <summary>
        /// GetSpecificAgentsOrders
        /// </summary>
        /// <param name="numberOfRow"></param>
        /// <param name="agentCodes"></param>
        /// <returns>List<Order></returns>
        public Task<List<Order>> GetSpecificAgentsOrders(int numberOfRow, string agentCodes)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}

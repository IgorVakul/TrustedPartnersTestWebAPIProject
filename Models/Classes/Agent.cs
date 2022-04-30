using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Agent : IAgent
    {
        #region Properties

        [Key]
        [Column(TypeName = "char(6)")]
        public string AGENT_CODE { get; set; }

        [Column(TypeName = "char(40)")]
        public string AGENT_NAME { get; set; }

        [Column(TypeName = "char(35)")]
        public string WORKING_AREA { get; set; }

        [Column(TypeName = "char(15)")]
        public string PHONE_NO { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string COUNTRY { get; set; }

        [Column(TypeName = "int")]
        public int COMMISSION { get; set; }

        #endregion Properties

        #region Constructors



        #endregion Constructors     

    }
}

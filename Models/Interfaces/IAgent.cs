using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    internal interface IAgent
    {
        #region Properties

        int COMMISSION { get; set; }
        string AGENT_CODE { get; set; }
        string AGENT_NAME { get; set; }
        string WORKING_AREA { get; set; }
        string PHONE_NO { get; set; }
        string COUNTRY { get; set; }

        #endregion Properties

        
    }
}

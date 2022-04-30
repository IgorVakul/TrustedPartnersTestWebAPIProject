using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces.DAL
{
    public interface IOrderDAL
    {
        public Task<List<Order>> GetSpecificAgentsOrders(int numberOfRow, string agentCodes);
    }
}

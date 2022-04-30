using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Interfaces;
using Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Classes.Services
{
    public class OrderService : BaseService, IOrderService
    {

        #region Members and constants

        protected readonly TestDBContext _context;

        #endregion Members and constants

        #region Constructors

        public OrderService(ILogger<OrderService> logger, TestDBContext context) : base(logger)
        {
            _context = context ?? throw new ArgumentNullException(paramName: nameof(context));
        }

        #endregion Constructors       

        #region Methods       

        /// <summary>
        /// GetSpecificAgentsOrders
        /// </summary>
        /// <param name="numberOfRow"></param>
        /// <param name="agentCodes"></param>
        /// <returns>Task<List<Order>></returns>
        public async Task<List<Order>> GetSpecificAgentsOrders(int numberOfRow, string agentCodes)
        {            
            return await _context.Orders.FromSqlInterpolated($"EXEC GetSpecificAgentsOrders @NumberOfRow={numberOfRow} , @AgentCodes={agentCodes}").ToListAsync();
        }

        #endregion Methods
    }
}

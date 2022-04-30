using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Classes.Services
{
    public class AgentService : BaseService, IAgentService
    {

        #region Members and constants

        protected readonly TestDBContext _context;

        #endregion Members and constants

        #region Constructors

        public AgentService(ILogger<AgentService> logger, TestDBContext context) : base(logger)
        {
            _context = context ?? throw new ArgumentNullException(paramName: nameof(context));
        }

        #endregion Constructors       

        #region Methods

        /// <summary>
        /// GetAgentCodeWithHighestSumOfAdvanceAmount
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns>Task<AgentCodeSPResult></returns>
        public async Task<AgentCodeSPResult> GetAgentCodeWithHighestSumOfAdvanceAmount(int year, byte quarter)
        {           
            var data = await _context.AgentCodeSPResults.FromSqlInterpolated($"EXEC GetAgentCodeWithHighestSumOfAdvanceAmount @Year={year} , @Quarter={quarter}").ToListAsync();
            return data.FirstOrDefault();
        }

        /// <summary>
        /// GetAgentsWithCountOfOrdersInYear
        /// </summary>
        /// <param name="year"></param>
        /// <param name="countOfOrders"></param>
        /// <returns>Task<List<AgentsListSPResult>></returns>
        public async Task<List<AgentsListSPResult>> GetAgentsWithCountOfOrdersInYear(int year, int countOfOrders)
        {
            return await _context.AgentsListSPResults.FromSqlInterpolated($"EXEC GetAgentsWithCountOfOrdersInYear @Year={year} , @CountOfOrders = {countOfOrders}").ToListAsync();
        }

        #endregion Methods

    }
}

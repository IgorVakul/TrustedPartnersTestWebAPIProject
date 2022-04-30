using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces.DAL
{
    public interface IAgentDAL
    {
        #region Methods

        /// <summary>
        /// GetAgentCodeWithHighestSumOfAdvanceAmount
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns>Task<List<AgentCodeSPResult>></returns>
        public Task<AgentCodeSPResult> GetAgentCodeWithHighestSumOfAdvanceAmount(int year, byte quarter);

        /// <summary>
        /// GetAgentsWithCountOfOrdersInYear
        /// </summary>
        /// <param name="year"></param>
        /// <param name="countOfOrders"></param>
        /// <returns>Task<List<Agent>></returns>
        public Task<List<AgentsListSPResult>> GetAgentsWithCountOfOrdersInYear(int year, int countOfOrders);

        #endregion Methods
    }
}

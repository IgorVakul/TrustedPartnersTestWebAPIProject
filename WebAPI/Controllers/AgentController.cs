using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Classes;
using Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Middleware;

namespace WebAPI.Controllers
{
    [ApiController]   
    public class AgentController : BaseController
    {
        #region Members and constants

        private readonly IAgentService _agentService;

        #endregion Members and constants

        #region Constructors

        public AgentController(ILogger<BaseController> logger, IAgentService _agentService) : base(logger)
        {
            this._agentService = _agentService ?? throw new ArgumentNullException(paramName: nameof(_agentService));
        }

        #endregion Constructors

        #region Web Methods

        [ServiceFilter(typeof(ClientIpCheckActionFilter))]
        [HttpGet]
        [Route("/GetAgentCodeWithHighestSumOfAdvanceAmount")]
        public async Task<ActionResult<AgentCodeSPResult>> GetAgentCodeWithHighestSumOfAdvanceAmount(int year, byte quarter)
        {
            try
            {
                AgentCodeSPResult agentCode = await _agentService.GetAgentCodeWithHighestSumOfAdvanceAmount(year, quarter);
                return agentCode==null? NoContent() : agentCode;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [ServiceFilter(typeof(ClientIpCheckActionFilter))]
        [HttpGet]
        [Route("/GetAgentsWithCountOfOrdersInYear")]
        public async Task<ActionResult<List<AgentsListSPResult>>> GetAgentsWithCountOfOrdersInYear(int year, int countOfOrders)
        {
            try
            {
                List<AgentsListSPResult> data = await _agentService.GetAgentsWithCountOfOrdersInYear(year, countOfOrders);
                return (data == null || !data.Any()) ? NoContent() : data;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion
    }
}

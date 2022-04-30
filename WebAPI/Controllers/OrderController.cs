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
    public class OrderController : BaseController
    {
        #region Members and constants

        private readonly IOrderService _orderService;

        #endregion Members and constants

        #region Constructors

        public OrderController(ILogger<BaseController> logger, IOrderService _orderService) : base(logger)
        {
            this._orderService = _orderService ?? throw new ArgumentNullException(paramName: nameof(_orderService));
        }

        #endregion Constructors

        #region Web Methods

        [ServiceFilter(typeof(ClientIpCheckActionFilter))]
        [HttpGet]
        [Route("/GetSpecificAgentsOrders")]
        public async Task<ActionResult<List<Order>>> GetSpecificAgentsOrders(int numberOfRow, string agentCodes)
        {
            try
            {
                List<Order> orders = await _orderService.GetSpecificAgentsOrders(numberOfRow, agentCodes);
                return (orders == null || !orders.Any()) ? NoContent() : orders;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        #endregion
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    public class BaseController : Controller
    {
        #region Data members/constants

        protected readonly ILogger<BaseController> _logger;

        #endregion

        #region Constructors

        public BaseController(ILogger<BaseController> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion
    }
}
